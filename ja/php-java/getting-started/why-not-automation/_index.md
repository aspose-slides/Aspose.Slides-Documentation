---
title: なぜ自動化ではないのか
type: docs
weight: 50
url: /ja/php-java/why-not-automation/
---

{{% alert color="primary" %}} 

Asposeで最もよく耳にする質問が2つあります： 


最初の質問は**製品を実行するためにMicrosoft Officeをインストールする必要がありますか？** 


短く単純な答えは**いいえ**です。AsposeおよびAsposeコンポーネントは完全に独立しており、Microsoft Corporationと提携していたり、承認、支援、またはその他の形で認可されているわけではありません。 


次に通常続く質問は**なぜMicrosoft Officeの自動化ではなくAspose製品を使用するべきなのでしょうか？** 


この質問には簡単に答えることはできません。私たちができる最も短い答えは、**Microsoft自身がソフトウェアソリューションからOfficeの自動化を強く推奨していないからです。** 

{{% /alert %}} 
## **概要**
上記のように、Asposeコンポーネントが自動化のより良い代替である理由は幾つかあります。主な理由は以下の通りです： 

- セキュリティ
- 安定性
- スケーラビリティ/速度
- 価格
- 機能

以下では、各主要ポイントについて詳しく説明します。また、独立したユーザー評価へのリンクを提供する**追加情報**セクションにも是非訪れてください。 
## **セキュリティ**
以下はMicrosoftの記事からの直接引用です： 


*"Officeアプリケーションはサーバーサイドでの使用を意図しておらず、したがって分散コンポーネントが直面するセキュリティ上の問題を考慮していません。Officeは着信リクエストを認証せず、サーバーサイドコードからマクロを意図せず実行したり、マクロを実行する可能性のある別のサーバーを起動されることから保護しません。匿名のWebからサーバーにアップロードされたファイルを開かないでください！最後に設定されたセキュリティ設定に基づき、サーバーは管理者またはシステムのコンテキストでフル権限でマクロを実行し、あなたのネットワークに危害を与える可能性があります！さらに、Officeは処理を加速するためにクライアント認証情報をキャッシュする多くのクライアントサイドコンポーネント（Simple MAPI、WinInet、MSDAIPPなど）を使用します。Officeがサーバーサイドで自動化されている場合、1つのインスタンスが複数のクライアントにサービスを提供する可能性があり、そのセッションのために認証情報がキャッシュされたため、あるクライアントが別のクライアントのキャッシュされた資格情報を使用し、他のユーザーを偽装して権限のないアクセス権を得る可能性があります。"* 


Aspose製品は非常に安全です。Asposeコンポーネントは重要なシステムリソースに対して潜在的なリスクを提供しません。さらに、Asposeコンポーネントによってドキュメントが開かれたとき、マクロは自動的に実行されません。Asposeコンポーネントは、開発者がOfficeファイルを作成、操作、および保存できるようにすることを目的に構築されました。Microsoft Officeパッケージに関連するリスクは、Asposeコンポーネントには内在していません。 
## **安定性**
以下はMicrosoftの記事からの直接引用です： 


*"Office 2000、Office XP、Office 2003は、エンドユーザーのためにインストール及び自己修復を容易にするためにMicrosoft Windows Installer（MSI）技術を使用しています。MSIは「初回使用時にインストール」という概念を導入し、機能を実行時に動的にインストールまたは構成できるようにします（システムのため、またはより頻繁には特定のユーザーのため）。サーバーサイド環境では、これによりパフォーマンスが低下し、インストールの承認や適切なインストールディスクの提供を求めるダイアログボックスが表示される可能性が高まります。エンドユーザー製品としてのOfficeのレジリエンスを高めるように設計されていますが、OfficeのMSI機能の実装はサーバーサイド環境では逆効果です。さらに、一般的にOfficeの安定性はサーバーサイドで実行される際には保証されず、この種類の使用のために設計またはテストされていません。ネットワークサーバー上でサービスコンポーネントとしてOfficeを使用することは、そのマシンの安定性を低下させ、結果としてネットワーク全体の安定性を低下させる可能性があります。もしサーバーサイドでOfficeを自動化する予定がある場合は、プログラムを重要な機能に影響を与えない専用のコンピューターに隔離し、必要に応じて再起動できるようにしておくべきです。"* 


Asposeコンポーネントは徹底的にテストされており、非常に安定しています。Asposeコンポーネントは、**IBM**、**ヒルトン**、**リーダーズダイジェスト**、**バンク・オブ・アメリカ**などの[企業](https://about.aspose.com/customers)に使用されています。 
## **スケーラビリティ/速度**
以下はMicrosoftの記事からの直接引用です： 


*"サーバーサイドコンポーネントは、高い再入可能性を持つマルチスレッドCOMコンポーネントでなければならず、オーバーヘッドが最小であり、複数のクライアントに対して高いスループットを提供する必要があります。Officeアプリケーションはほぼすべての点で正反対です。単一のクライアントのために多様でありながらリソースを多く消費する機能を提供する非再入可能なSTAベースの自動化サーバです。サーバーサイドのソリューションとしてのスケーラビリティはわずかであり、メモリなどの重要な要素には固定された制限があり、設定で変更することはできません。さらに重要なことに、グローバルリソース（メモリマップファイル、グローバルアドインまたはテンプレート、および共有自動化サーバーなど）を使用し、同時に実行できるインスタンスの数を制限し、マルチクライアント環境で構成されている場合にはレースコンディションを引き起こす可能性があります。同時に任意のOfficeアプリケーションのインスタンスを複数実行する予定の開発者は、***プーリング***または***アクセスの直列化***を考慮する必要があります。そうすることで、潜在的な***デッドロック***や***データ破損***を避けることができます。* 


Asposeコンポーネントは高いスケーラビリティと驚異的な速度を誇ります。Officeアプリケーションは数百人や数千人のユーザーによって同時に使用されることを想定して設計されていません。しかし、Asposeコンポーネントはまさにそれを目指して設計されています。私たちのコンポーネントは、単一のサーバー上でも、一つのアプリケーションに電力を供給する形でも、エンタープライズ全体のアプリケーションを支える負荷分散されたWebフォーム上でも、完璧に機能します。 
## **価格**
アプリケーションがMicrosoft Office Automationを利用する場合、アプリケーションを実行する各マシン用にMicrosoft Officeのコピーを購入する必要があります。アプリケーションがOfficeファイルを作成または操作する必要がある場合でも、ユーザーがMicrosoft Officeを持っている必要はないことが多々あります。Asposeは、無制限のユーザーにデプロイできる非常に[コスト効率の高い](https://purchase.aspose.com/)ロイヤリティ無料の再配布ライセンスを提供しており、ライセンスの心配はありません。 


Webベースのアプリケーションを作成する際は、Microsoft Office Automationコンポーネントはサーバーサイドソリューション向けに価格設定されていないため、Microsoft Officeコンポーネントを利用するWebアプリケーションをデプロイするための良いライセンスソリューションがないことを知っておくことが重要です。Asposeはサーバーベースのアプリケーション向けにも非常にコスト効率の高いソリューションを提供しています。 
## **機能**
AsposeコンポーネントはOfficeファイルを管理するために必要なすべてのものを提供し、更に多くのものを提供します。彼らは、開発者が最小限の労力で最大の成果を上げられるように設計されています。Office Automationとは異なり、Asposeコンポーネントは多くの強力で時間を節約する機能を提供します。例えば、[Aspose.Cells](https://products.aspose.com/cells/php-java/)は、開発者が**DataTable**や**DataView**から直接Excelファイルにデータをインポートする機能を提供します。[Aspose.Words](https://products.aspose.com/words/php-java/)は、開発者がWord（マージ文書）を入力するための類似の機能を提供します。[Asposeファミリー内のすべてのコンポーネント](https://products.aspose.com/total/php-java/)は、それぞれ独自で強力な機能を提供します。


Asposeコンポーネント（または[Aspose.Total](https://products.aspose.com/total/php-java/)のようなコンポーネントスイート）を購入する最良の点は、私たちの開発チームへのアクセスが得られることです。私たちの開発チームは、もしあなたの会社が必要な機能があれば、他の会社も同様のものが必要である可能性が高いことを理解しています。すべての機能リクエストを追加することはできませんが、私たちのチームは支援を提供する際に非常にオープンマインドで柔軟性を持つよう努めています。その考え方が、Asposeコンポーネントをこれほど強力にする手助けとなっています。Office Automationオブジェクトからの追加機能が必要な場合、それらが追加される可能性は非常に低いです。
## **結論**
{{% alert color="primary" %}} 

この記事は、AsposeコンポーネントがOffice Automationよりも優れた選択である理由の多くの主要なポイントを扱っていますが、他にもたくさんの理由があります。この記事は主に最も重要なポイントのみを扱っています。すべての異なるAsposeコンポーネントは、リスクフリーで無義務の[評価版](https://downloads.aspose.com/slides/java)を提供しています。私たちはあなたがその評価を利用し、Asposeがあなたのアプリケーションに何ができるかをより良く理解できるようにすることをお勧めします。 

{{% /alert %}} 