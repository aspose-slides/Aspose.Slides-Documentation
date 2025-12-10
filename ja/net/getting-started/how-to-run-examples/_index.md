---
title: サンプルの実行方法
type: docs
weight: 130
url: /ja/net/how-to-run-examples/
keywords:
- 例
- ソフトウェア要件
- NuGet
- GitHub
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET のサンプルをすばやく実行するには、リポジトリをクローンし、パッケージを復元してからビルドし、PPT、PPTX、ODP の機能をテストします。"
---

## **ソフトウェア要件**
例をダウンロードして実行する前に、環境が以下の要件を満たしていることを確認してください。

- Visual Studio 2010 以上。
- Visual Studio に NuGet パッケージ マネージャーがインストールされていること。最新の NuGet API バージョンがインストールされていることを確認してください。

NuGet パッケージ マネージャーのインストール手順については、次のページをご参照ください: https://docs.microsoft.com/en-us/nuget/install-nuget-client-tools

1. **Tools** > **Options** > **NuGet Package Manager** に進みます。

1. **NuGet Package Manager** を展開（ダブルクリック）し、**Package Sources** を選択します。

1. nuget.org パラメーターが選択されていることを確認します。

   このサンプル プロジェクトは NuGet の自動パッケージ復元機能を使用しているため、インターネット接続が必要です。

   例を実行するマシンでインターネット接続が利用できない場合は、[Installation](https://docs.aspose.com/slides/net/installation/) を確認し、（手動で）例のプロジェクトに Aspose.Slides.dll の参照を追加してください。

## **GitHub から Aspose.Slides をダウンロード**
.NET 用 Aspose.Slides のすべてのサンプルは [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET) でホストされています。

好きな GitHub クライアントでリポジトリをクローンするか、ZIP ファイルを [here](https://github.com/aspose-slides/Aspose.Slides-for-.NET/archive/master.zip) からダウンロードできます。

1. ZIP ファイルをダウンロードした場合は、内容をコンピューター上のフォルダーに展開する必要があります。  
   すべてのサンプルは **Examples** フォルダーに格納されています。  
   C# の Visual Studio ソリューション ファイルがあります。プロジェクトは Visual Studio 2013 で作成されていますが、ソリューション ファイルは Visual Studio 2010 SP1 以降と互換性があります。

2. Visual Studio でソリューション ファイルを開き、プロジェクトをビルドします。  
   初回の実行時に、依存関係が NuGet を通じて自動的にダウンロードされます。  
   **Examples** のルート フォルダーにある **Data** フォルダーには、C# のサンプルで使用される入力ファイルが含まれています。**Data** フォルダーをサンプル プロジェクトと一緒にダウンロードする必要があります。

3. RunExamples.cs ファイルを開きます。すべてのサンプルはここから呼び出されます。

4. プロジェクト内で実行したいサンプルのコメントを解除します。

セットアップやサンプルの実行に問題がある場合は、フォーラムでお気軽にお問い合わせください。

## **貢献**
サンプルを追加または改善することでプロジェクトに貢献できます。リポジトリ内のすべてのサンプルとショーケース プロジェクトはオープンソースであるため、あなた（および他のユーザー）はアプリケーションで自由に利用できます。

貢献するには、リポジトリをフォークし、ソースコードを編集してプル リクエストを作成してください。変更内容を確認し、有用と判断した場合はリポジトリに追加します。