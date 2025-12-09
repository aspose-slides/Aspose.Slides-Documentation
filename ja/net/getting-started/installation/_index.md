---
title: インストール
type: docs
weight: 70
url: /ja/net/installation/
keywords:
- Aspose.Slides のインストール
- Aspose.Slides のダウンロード
- Aspose.Slides の使用
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
description: "Aspose.Slides for .NET をすばやくインストールする方法を学びます。ステップバイステップのガイド、システム要件、コードサンプルを提供し、今日から PowerPoint プレゼンテーションの操作を開始できます！"
---

## **Windows**
NuGet は、PC 上で .NET 用 Aspose API をダウンロードおよびインストールする最も簡単な方法を提供します。

### **方法 1: NuGet パッケージ マネージャーから Aspose.Slides をインストールまたは更新**
1. Microsoft Visual Studio を開きます。  
2. 簡単なコンソール アプリを作成するか、既存のプロジェクトを開きます。  
3. **Tools** > **NuGet package manager** を選択します。  
4. **Browse** の下で、テキスト フィールドに *Aspose Slides* を検索します。  
{{% image img="installation_1.png" alt="Aspose.Slides Installation from NuGet Package Manager - 1" %}}
5. **Aspose.Slides.NET** をクリックし、次に **Install** をクリックします。  
   * すでにインストール済みで Aspose.Slides を更新したい場合は、代わりに **Update** をクリックします。  

選択した API がダウンロードされ、プロジェクトに参照として追加されます。

### **方法 2: パッケージ マネージャー コンソールから Aspose.Slides をインストールまたは更新**
パッケージ マネージャー コンソールを使用して [Aspose.Slides API](https://www.nuget.org/packages/Aspose.Slides.NET/) を参照する方法は次のとおりです。
1. Microsoft Visual Studio を開きます。  
2. 簡単なコンソール アプリを作成するか、既存のプロジェクトを開きます。  
3. **Tools** > **Library Package Manager** > **Package Manager Console** を選択します。  
![todo:image_alt_text](installation_2.png)
4. 次のコマンドを実行します: `Install-Package Aspose.Slides.NET`  
![todo:image_alt_text](installation_3.png)
最新のフル リリースがアプリケーションにインストールされます。  

* あるいは、コマンドに `-prerelease` サフィックスを付加して、最新リリース（ホットフィックスを含む）もインストールするよう指定できます。  

**Installing Aspose.Slides.NET** のヒントがウィンドウ下部付近に表示されます。  
![todo:image_alt_text](installation_4.png)

ダウンロードが完了すると、いくつかの確認メッセージが表示されます。

もし [Aspose EULA](https://about.aspose.com/legal/eula) に慣れていない場合は、URL に記載されたライセンスを読むことをお勧めします。  
![todo:image_alt_text](installation_5.png)

アプリケーション内で、Aspose.Slides が正常に追加され参照されていることが確認できます。  
![todo:image_alt_text](installation_6.png)

Package Manager Console では、`Update-Package Aspose.Slides.NET` コマンドを実行して Aspose.Slides パッケージの更新を確認できます。更新が見つかった場合は自動的にインストールされます。また、`-prerelease` サフィックスを使用して最新リリースを更新することもできます。  

#### **共有サーバー環境で実行する際の考慮事項**
Aspose の .NET コンポーネントは、レジストリ設定や仮想ディレクトリ以外の場所にあるファイル（たとえばフォントの読み取り）が必要になることがあるため、**Full Trust** 権限セットで実行することを強く推奨します。  

さらに、Aspose.NET コンポーネントはコア .NET システム クラスに基づいており、場合によってはそれらのクラスでも操作に Full Trust 権限が必要です。  

複数の企業のアプリケーションをホストするインターネットサービスプロバイダーは、ほとんどの場合 Medium Trust セキュリティ レベルを適用します。.NET 2.0 の場合、このセキュリティ レベルは Aspose.Slides の動作に影響を与える制約を招くことがあります：
- **RegistryPermission** が使用できません。これにより、ドキュメントのレンダリング時にインストールされたフォントを列挙するために必要なレジストリへのアクセスができなくなります。  
- **FileIOPermission** が制限されています。これにより、アプリケーションの仮想ディレクトリ階層内のファイルのみアクセス可能になります。エクスポート操作時にフォントが読み取れない可能性があります。  

以上の理由から、Aspose.Slides は **Full Trust** 権限で実行することを強く推奨します。**Medium trust** を使用すると、一部のライブラリ機能（たとえばレンダリング）が特定のタスク実行時に動作しないなどの不整合が発生する可能性があります。  

## **macOS**
NuGet は、macOS 上で .NET 用 Aspose.Slides をダウンロードおよびインストールする最も簡単な方法を提供します。

**前提条件のインストール**
`System.Drawing` 名前空間は macOS では動作が異なるため、mono-libgdiplus をインストールする必要があります。

> .NET 5 以前のバージョンでは、[System.Drawing.Common](https://www.nuget.org/packages/System.Drawing.Common/) NuGet パッケージは Windows、Linux、macOS で動作します。ただし、プラットフォーム間でいくつかの違いがあります。Linux と macOS では、GDI+ の機能は [libgdiplus](https://www.mono-project.com/docs/gui/libgdiplus/) ライブラリで実装されています。このライブラリは多くの Linux ディストリビューションではデフォルトでインストールされておらず、Windows や macOS の GDI+ のすべての機能をサポートしていません。また、libgdiplus がまったく利用できないプラットフォームもあります。Linux と macOS で System.Drawing.Common パッケージの型を使用するには、libgdiplus を別途インストールする必要があります。詳細は、[Install .NET on Linux](https://docs.microsoft.com/en-us/dotnet/core/install/linux) または [Install .NET on macOS](https://docs.microsoft.com/en-us/dotnet/core/install/macos#libgdiplus) を参照してください。

mac に mono-libgdiplus を個別にインストールするには、.NET ドキュメントの [this article](https://docs.microsoft.com/en-us/dotnet/core/install/macos#libgdiplus) を参照してください。

### **Aspose.Slides のインストール**
1. Visual Studio を開きます。  
2. 簡単なコンソール アプリを作成するか、既存のプロジェクトを開きます。  
3. **Project** > **Manage NuGet Packages...** を選択します。  
![path-to-nuget-macos](path-to-nuget-macos.png)
4. テキスト フィールドに *Aspose.Slides* と入力します。  
5. **Aspose.Slides for .NET** をクリックし、次に **Add Package** をクリックします。  
6. 簡単なコード スニペットを追加します。  
   * コードは [this page](/slides/ja/net/create-presentation/) からコピーできます。  
7. アプリを実行します。  
8. プロジェクトの *folder/bin/Debug/presentation_file_name* を開きます。  

## **FAQ**
**無料版やトライアルの制限はありますか？**
はい、デフォルトでは Aspose.Slides は評価モードで実行され、透かしが表示され、他の制限がある場合があります。制限を解除するには、有効な [license](/slides/ja/net/licensing/) を適用する必要があります。