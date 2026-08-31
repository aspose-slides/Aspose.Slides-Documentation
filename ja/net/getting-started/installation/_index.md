---
title: インストール
type: docs
weight: 70
url: /ja/net/installation/
keywords:
- Aspose.Slides をインストール
- Aspose.Slides をダウンロード
- Aspose.Slides を使用
- Aspose.Slides のインストール
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET をすばやくインストールする方法を学びます。ステップバイステップのガイド、システム要件、コードサンプル — 今日から PowerPoint プレゼンテーションの作成を始めましょう！"
---
## **概要**

この記事では、Windows、Linux、macOSで Aspose.Slides for .NET をインストールする方法を説明します。NuGet ベースのインストールに焦点を当て、Windows で NuGet パッケージ マネージャーまたはパッケージ マネージャー コンソールを使用してライブラリを追加する方法、Linux の .NET プロジェクトへの追加方法、macOS の Visual Studio プロジェクトへの追加方法を示します。また、パッケージの更新方法と、必要に応じてプレリリース ビルドをインストールする方法も説明します。

インストール前に、[システム要件](/slides/ja/net/system-requirements/)でサポートされているオペレーティングシステム、.NET 実装、および追加の依存関係を確認してください。

## **Windows**
NuGet は、PC 上で .NET 用の Aspose API をダウンロードおよびインストールする最も簡単な方法を提供します。

### **方法 1: NuGet パッケージ マネージャーから Aspose.Slides をインストールまたは更新する**

1. Microsoft Visual Studio を開きます。  
2. 簡単なコンソール アプリを作成するか、既存のプロジェクトを開きます。  
3. **ツール** > **NuGet パッケージ マネージャー** を開きます。  
4. **参照** の下で、テキスト フィールドに *Aspose Slides* を検索します。  
{{% image img="installation_1.png" alt="Aspose.Slides Installation from NuGet Package Manager - 1" %}}
5. **Aspose.Slides.NET** をクリックし、次に **インストール** をクリックします。  
   * すでにインストール済みで Aspose.Slides を更新したい場合は、代わりに **更新** をクリックします。  

選択した API がダウンロードされ、プロジェクトに参照として追加されます。

### **方法 2: パッケージ マネージャー コンソール経由で Aspose.Slides をインストールまたは更新する**

パッケージ マネージャー コンソールを使用して [Aspose.Slides API](https://www.nuget.org/packages/Aspose.Slides.NET/) を参照する方法は次のとおりです:

1. Microsoft Visual Studio を開きます。  
2. 簡単なコンソール アプリを作成するか、既存のプロジェクトを開きます。  
3. **ツール** > **ライブラリ パッケージ マネージャー** > **パッケージ マネージャー コンソール** を開きます。  
![todo:image_alt_text](installation_2.png)
4. 次のコマンドを実行します: `Install-Package Aspose.Slides.NET`  
![todo:image_alt_text](installation_3.png)
最新のフルリリースがアプリケーションにインストールされます。  

* あるいは、コマンドに `-prerelease` サフィックスを追加して、最新リリース（ホットフィックスを含む）もインストールできるように指定できます。  

ウィンドウの下部付近に **Installing Aspose.Slides.NET** ヒントが表示されます。  
![todo:image_alt_text](installation_4.png)

ダウンロードが完了すると、いくつかの確認メッセージが表示されます。  

[Aspose EULA](https://about.aspose.com/legal/eula) に詳しくない場合は、URLで参照されているライセンスを読むことをお勧めします。  
![todo:image_alt_text](installation_5.png)

アプリケーションで、Aspose.Slides が正常に追加および参照されたことが確認できます。  
![todo:image_alt_text](installation_6.png)

パッケージ マネージャー コンソールで `Update-Package Aspose.Slides.NET` コマンドを実行すると、Aspose.Slides パッケージの更新を確認できます。更新が見つかった場合は自動的にインストールされます。また、`-prerelease` サフィックスを使用して最新リリースを更新することもできます。

#### **共有サーバー環境で実行する際の考慮事項**
すべての Aspose .NET コンポーネントは、**フル トラスト** パーミッション セットで実行することを強く推奨します。これは、Aspose コンポーネントがレジストリ設定や仮想ディレクトリ以外の場所にあるファイルにアクセスする必要がある場合があるためです（例: フォントの読み取り）。  

さらに、Aspose.NET コンポーネントはコア .NET システム クラスに基づいており、これらのクラスの一部は特定の操作にフル トラスト権限が必要です。  

インターネットサービスプロバイダーは、複数の企業からのアプリケーションをホストする際に、主にミディアム トラスト セキュリティ レベルを適用します。.NET 2.0 の場合、このセキュリティ レベルにより Aspose.Slides の動作に影響を与える制約が生じることがあります：

- **RegistryPermission** が利用できません。これは、ドキュメントのレンダリング時にインストールされているフォントを列挙するために必要なレジストリへのアクセスができないことを意味します。  
- **FileIOPermission** が制限されています。これは、アプリケーションの仮想ディレクトリ階層内のファイルのみアクセスできることを意味します。フォントの読み取りがエクスポート時にできない可能性もあります。  

上記の理由から、Aspose.Slides は **フル トラスト** 権限で実行することを強く推奨します。**ミディアム トラスト** を使用すると、いくつかのライブラリ機能（例: レンダリング）が特定のタスクで動作しないなどの不整合が発生する可能性があります。

## **Linux**
NuGet は、Linux 上で .NET 用の Aspose.Slides をダウンロードおよびインストールする最も簡単な方法を提供します。[Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) パッケージを .NET プロジェクトに追加してください。

## **macOS**
NuGet は、macOS 上で .NET 用の Aspose.Slides をダウンロードおよびインストールする最も簡単な方法を提供します。

### **Aspose.Slides のインストール**

1. Visual Studio を開きます。  
2. 簡単なコンソール アプリを作成するか、既存のプロジェクトを開きます。  
3. **プロジェクト** > **NuGet パッケージの管理...** を開きます。  
![path-to-nuget-macos](path-to-nuget-macos.png)
4. テキスト フィールドに *Aspose.Slides* と入力します。  
5. **Aspose.Slides for .NET** をクリックし、次に **パッケージの追加** をクリックします。  
6. 簡単なコード スニペットを追加します。  
   * [このページ](/slides/ja/net/create-presentation/) のコードをコピーできます。  
7. アプリを実行します。  
8. プロジェクトの *folder/bin/Debug/presentation_file_name* を開きます。

## **FAQ**

**無料版や試用版の制限はありますか？**

はい、デフォルトでは Aspose.Slides は評価モードで実行され、透かしが表示され、他の制限がある場合があります。制限を解除するには、有効な [ライセンス](/slides/ja/net/licensing/) を適用する必要があります。