---
title: サンプルを実行する方法
type: docs
weight: 130
url: /ja/net/how-to-run-examples/
---

## **ソフトウェア要件**
サンプルをダウンロードして実行する前に、あなたの環境が以下の要件を満たしていることを確認してください：

- Visual Studio 2010 以降。
- Visual Studio に NuGet パッケージマネージャーがインストールされていること。最新の NuGet API バージョンが Visual Studio にインストールされていることを確認してください。

NuGet パッケージマネージャーのインストール手順については、以下のページをご覧ください: https://docs.microsoft.com/en-us/nuget/install-nuget-client-tools

1. **ツール** > **オプション** > **NuGet パッケージマネージャー** に進みます。

1. **NuGet パッケージマネージャー** を展開（ダブルクリック）し、次に **パッケージソース** を選択します。

1. nuget.org のパラメータが選択されていることを確認します。

   サンプルプロジェクトは NuGet 自動パッケージ復元機能を使用しているため、インターネット接続が必要です。

   サンプルを実行する予定のマシンにアクティブなインターネット接続がない場合は、[インストール](https://docs.aspose.com/slides/net/installation/)を確認し、（手動で）サンプルプロジェクトに Aspose.Slides.dll への参照を追加してください。
## **GitHub からダウンロード**
すべての Aspose.Slides for .NET のサンプルは [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET) にホストされています。

お気に入りの GitHub クライアントを使用してリポジトリをクローンするか、ZIP ファイルを [こちら](https://github.com/aspose-slides/Aspose.Slides-for-.NET/archive/master.zip) からダウンロードできます。

1. ZIP ファイルをダウンロードした場合は、その内容をコンピューターのフォルダーに解凍する必要があります。

すべてのサンプルは **Examples** フォルダーに保存されています。

C# の Visual Studio ソリューションファイルがあります。プロジェクトは Visual Studio 2013 で作成されていますが、ソリューションファイルは Visual Studio 2010 SP1 以降と互換性があります。

2. Visual Studio でソリューションファイルを開き、プロジェクトをビルドします。

   初回実行時に、依存関係は自動的に NuGet 経由でダウンロードされます。

**Examples** のルートフォルダー内の **Data** フォルダーには、C# のサンプルで使用される入力ファイルが含まれています。サンプルプロジェクトと一緒に **Data** フォルダーをダウンロードする必要があります。

3. RunExamples.cs ファイルを開きます。すべてのサンプルはここから呼び出されます。

4. プロジェクト内で実行したいサンプルのコメントを外します。

設定やサンプルの実行に問題がある場合は、フォーラムでお気軽にお知らせください。
## **貢献する**
サンプルを追加または改善することでプロジェクトに貢献できます。リポジトリ内のすべてのサンプルとショーケースプロジェクトはオープンソースであるため、あなた（および他の人々）がアプリケーションで自由に使用できます。

貢献するには、リポジトリをフォークし、ソースコードを編集してプルリクエストを作成します。変更をレビューしますので、役立つと判断した場合はリポジトリに追加します。