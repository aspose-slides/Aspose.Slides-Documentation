---
title: ASP.NET Coreでバックグラウンドタスクを実行する方法
type: docs
weight: 300
url: /net/how-to-run-background-tasks-in-asp-net-core/
---

## **概要**
ファイル処理（例：プレゼンテーションをPDFにエクスポートする）は、典型的なサーバー側のタスクです。リクエストハンドラ内での単純なファイル処理（クライアントが待機している間にサーバーが作業を行う）は、以下の欠点があります：

- *ユーザーインターフェイスが不十分*。ページがフリーズし、ユーザーは結果を待つ必要があります。ページのリロードはタスクをキャンセルします。
- *操作タイムアウト*。処理が固定の時間内に完了することを保証できないため、ユーザーは遅かれ早かれ「操作タイムアウト」を見ることになります。
- *スループットとスケーラビリティが低い*。ASP.NET Coreは多くのリクエストを非同期で処理するように設計されています。CPUバウンドの長時間実行タスクはスレッドをブロックし、サーバーのスループットを低下させます。
- *耐障害性が悪い*。長時間実行タスクの途中で何かがうまくいかない場合（例：接続の問題）、処理は単に失敗し、再度最初から処理をやり直す必要があります。

[A より良いアプローチ](https://docs.microsoft.com/en-us/aspnet/core/performance/performance-best-practices#complete-long-running-tasks-outside-of-http-requests)は、最初にジョブを非同期にスケジュールし、次にバックグラウンドで完了させ、最後に処理結果を返すことです。

この場合、ユーザーは実際のステータスを確認でき（ページを離れたりリロードしたりすることも可能）、サーバーのリソースを効率的にスケーリングし、柔軟に調整できます。また、リトライポリシーも利用できます。

したがって、典型的なバックグラウンド処理ソリューションには、以下の部分が含まれます：
1. ジョブをスケジュールするためのAPI。
2. ジョブステータスを追跡するためのAPI。
3. スケジュールされたジョブを処理するためのバックグラウンドワーカー。
4. 結果を保存/取得するためのAPI。

## **バックグラウンドタスクの例**
このアプローチを示すために、[**例としてのASP.NET Core 3.1ウェブアプリケーション**](https://wiki.lutsk.dynabic.com/download/Aspose%20Slides/slidesnet/Discussion%20on%20Russian/Issues/Platform%20specific/How%20to%20run%20Background%20Tasks%20in%20ASP.NET%20Core/WebHome/BackgroundJobDemo.zip?rev=1.1)を考えてみましょう。このウェブアプリには、ユーザーがプレゼンテーションをアップロードし、「PDFにエクスポート」ボタンを押すことができるウェブページが含まれています。その後、プレゼンテーションはアップロードされ、バックグラウンドワーカーによってPDF形式に変換されます。

## **ウェブアプリ**
例のウェブアプリ（*BackgroundJobDemo*プロジェクト）は以下を含んでいます：

- ファイルアップロードページ（Razorページのアップロード）。
- 進捗ページ（進捗を確認し表示するためのいくつかのJavaScript関数を持つRazorページの進捗）。
- 処理ステータスを提供するコントローラー（JobStatusController）（api/status/{jobId}）。
- エクスポートされたPDFファイルを返すコントローラー（JobResultController）（api/result/{id}）。
- ASP.NET Coreホスティングサービスに基づいたバックグラウンドワーカー（WorkerServiceクラスを参照）。

Razorページ、コントローラー、バックグラウンドワーカーはすべて、*BackgroundJobDemo.Common*プロジェクトで定義されたインターフェースを介して実際の作業を委任します。ジョブ管理と処理の具体的な実装は別のプロジェクト（*BackgroundJobDemo.Local*、*BackgroundJobDemo.Aws*など）で定義され、Startup.ConfigureServicesメソッドで簡単に切り替えることが可能です。

デモ目的で「アップロード」ページはバッファリングモデルバインディングを使用しますが、大きなファイルのアップロードにはバッファなしのストリーミングが[推奨](https://docs.microsoft.com/en-us/aspnet/core/mvc/models/file-uploads)されています。本番環境でのデプロイメントでは、[セキュリティの側面](https://docs.microsoft.com/en-us/aspnet/core/mvc/models/file-uploads#security-considerations)を考慮する必要があります。「進捗」ページは、JavaScriptを介して2秒ごとにスケジュールされたジョブのステータスをポーリングします（この周期は変更可能です）。ステータスポーリングは典型的な挙動ですが、高度なケースでは、WebSocketを介したリアルタイム通知（リアルタイム通信はこの文書の範囲外）を必要とすることがあります。[SignalR](https://dotnet.microsoft.com/apps/aspnet/signalr)はリアルタイム通信のためのシンプルでありながら強力なツールです。

サーバープロセスでのバックグラウンドワーカーのホスティングは、シンプルなアプリケーションには便利ですが、[欠点](https://haacked.com/archive/2011/10/16/the-dangers-of-implementing-recurring-background-tasks-in-asp-net.aspx)もあります。より堅牢でスケーラブルなソリューションは、ワーカーを別プロセスにデプロイすることです（例：*BackgroundJobDemo.Worker*コンソールアプリケーションを参照）。

## **基本的な実装**
*BackgroundJobDemo.Local*プロジェクトは、SQLiteデータベースを用いたシンプルなジョブ管理の実装を含んでいます（データベースファイルへのパスはLocalConfig.DbFilePath経由で指定されており、Startup.ConfigureServicesで確認できます）。アップロードされたファイルと処理されたファイルはファイルシステムに保存されます（ストレージフォルダーへのパスはLocalConfig.FileStorageFolderPath経由で指定されており、Startup.ConfigureServicesで確認できます）。実際のアプリケーションにおける耐障害性とパフォーマンスの向上のために、ジョブスケジューリングはメッセージキュー（例：RabbitMQ、AWS SQS、Azure Storage Queue）を介して実装されるべきです。

## **Amazon Web Servicesに基づいた分散実装**
*BackgroundJobDemo.Aws*プロジェクトはAmazon Web Servicesを介ったジョブ処理を実装しており、水平スケーリングが可能な分散アーキテクチャを示します。以下のコンポーネントを含んでいます：

- ウェブアプリ - ユーザーとインタラクションし、PPTXをPDFにエクスポートするタスクなどをスケジュールします。
- ワーカー - エクスポートを処理します（プロセス内、プロセス外、またはAmazon Lambda）。
- メッセージキュー - 処理されるタスクを保存します（Amazon SQS）。
- ファイルストレージ - アップロードされたファイルと処理されたファイルを保持します（Amazon S3）。
- キー・バリューストレージ - タスク処理ステータスを提供します（Amazon DynamoDB）。

典型的な分散アーキテクチャは[メッセージキュー](https://aws.amazon.com/message-queue/)に基づいています：ウェブアプリはバックグラウンドタスクをキューに入れ、バックグラウンドワーカーがそのキューからタスクを取得して必要な作業を行います。したがって、システムコンポーネント（ウェブアプリとバックグラウンドワーカー）は疎結合されており、処理は非同期で信頼性の高いものです。キューはすべてのメッセージ（タスク）がワーカーに配信されることを保証します。キューメッセージには*可視性タイムアウト*があり、1つのワーカーがメッセージを処理のために取得すると、そのメッセージは他のワーカーから見えなくなります。そして、メッセージを処理しているワーカーだけがそのメッセージをキューから削除します。処理が可視性タイムアウト内に完了しない場合（例：失敗またはネットワークの問題）、未処理のメッセージは再びワーカーに表示されます。

私たちの実装では、[Amazon Simple Queue Service](https://aws.amazon.com/sqs/)（SQS）を使用しています - マイクロサービス、分散システム、およびサーバーレスアプリケーション用に完全に管理されたメッセージキューです。

メッセージキューは軽量なメッセージ用に設計されているため（例：SQSメッセージサイズの制限は256KB）、タスクの記述のみを含むべきです。すべての重いデータ（例：処理されるファイル）は別のストレージに置かれ、メッセージから参照されるべきです。[Amazon S3](https://aws.amazon.com/s3/)は任意の量のデータをどこからでも保存および取得するために構築されたオブジェクトストレージです。このサービスはアップロードされたファイルと処理されたファイルの保存に利用されます。

キー・バリューストレージは、IDごとにジョブ処理の結果を保存および取得するために必要です。[Amazon DynamoDB](https://aws.amazon.com/dynamodb/)（どんなスケールにも適応する高速で柔軟なNoSQLデータベースサービス）がこの例で利用されました。

Amazon Web Servicesでデモアプリを実行するには：

1. 同じAWSリージョンで作成して構成します：
   1. SQSキュー、
   1. S3バケット、
   1. DynamoDBテーブル。
1. Startup.ConfigureServicesからAddAws拡張メソッドを使用して（SQSキューURL、S3バケット名、DynamoDBテーブル名、AWSリージョン）、作成したサービスにウェブアプリを接続します。

## **参考文献**
- ASP.NET Core パフォーマンスベストプラクティス <https://docs.microsoft.com/en-us/aspnet/core/performance/performance-best-practices>
- ASP.NET Coreでのファイルアップロード <https://docs.microsoft.com/en-us/aspnet/core/mvc/models/file-uploads>
- SignalRによるリアルタイムASP.NET <https://dotnet.microsoft.com/apps/aspnet/signalr>
- メッセージキュー <https://aws.amazon.com/message-queue/>
- Amazon Simple Queue Service <https://aws.amazon.com/sqs/>
- Amazon S3 <https://aws.amazon.com/s3/>
- Amazon DynamoDB <https://aws.amazon.com/dynamodb/>