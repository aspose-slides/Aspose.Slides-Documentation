---
title: インストール
type: docs
weight: 70
url: /ja/net/installation/
keywords: "Aspose.Slides のダウンロード, Aspose.Slides のインストール, Aspose.Slides のインストール手順, Windows, macOS, .NET"
description: "Windows または macOS で .NET 用 Aspose.Slides をインストール"
---

## **Windows**
NuGet は、PC 上で .NET 用 Aspose API をダウンロードおよびインストールする最も簡単な方法を提供します。

### **Method 1: Install or Update Aspose.Slides from the NuGet Package Manager**

1. Microsoft Visual Studio を開きます。  
2. 簡単なコンソール アプリを作成するか、既存のプロジェクトを開きます。  
3. **Tools** > **NuGet package manager** を選択します。  
4. **Browse** の下のテキスト フィールドに *Aspose Slides* と入力して検索します。  
{{% image img="installation_1.png" alt="Aspose.Slides Installation from NuGet Package Manager - 1" %}}
5. **Aspose.Slides.NET** をクリックし、続いて **Install** をクリックします。  
   * すでにインストール済みで更新したい場合は、**Update** をクリックしてください。

選択した API がダウンロードされ、プロジェクトに参照として追加されます。

### **Method 2: Install or Update Aspose.Slides Through the Package Manager Console**

パッケージ マネージャ コンソールから [Aspose.Slides API](https://www.nuget.org/packages/Aspose.Slides.NET/) を参照する方法は次のとおりです。

1. Microsoft Visual Studio を開きます。  
2. 簡単なコンソール アプリを作成するか、既存のプロジェクトを開きます。  
3. **Tools** > **Library Package Manager** > **Package Manager Console** を選択します。  
![todo:image_alt_text](installation_2.png)
4. 次のコマンドを実行します: `Install-Package Aspose.Slides.NET`  
![todo:image_alt_text](installation_3.png)
最新のフル リリースがアプリケーションにインストールされます。

* 代わりにコマンドに `-prerelease` サフィックスを追加すると、最新リリース（ホットフィックス含む）をインストールできます。

**Installing Aspose.Slides.NET** のヒントがウィンドウ下部に表示されます。  
![todo:image_alt_text](installation_4.png)

ダウンロードが完了すると、確認メッセージが表示されます。

[Aspose EULA](https://about.aspose.com/legal/eula) に不慣れな場合は、URL に記載されているライセンスを確認してください。  
![todo:image_alt_text](installation_5.png)

アプリケーション内で Aspose.Slides が正常に追加および参照されたことが確認できます。  
![todo:image_alt_text](installation_6.png)

Package Manager Console では `Update-Package Aspose.Slides.NET` コマンドを実行して Aspose.Slides パッケージの更新を確認できます。更新が見つかれば自動的にインストールされます。`-prerelease` サフィックスを使用して最新リリースを更新することも可能です。

#### **Considerations When Running on a Shared Server Environment**
Aspose .NET コンポーネントは、レジストリ設定や仮想ディレクトリ以外の場所にあるファイル（例: フォント）へのアクセスが必要になることがあるため、**Full Trust** 権限セットで実行することを強く推奨します。

さらに、Aspose.NET コンポーネントはコア .NET システム クラスに基づいており、これらのクラスの一部は特定の操作に Full Trust 権限を必要とします。

複数の企業のアプリケーションをホストする ISP では、主に **Medium Trust** セキュリティ レベルが適用されます。.NET 2.0 環境では、このセキュリティ レベルが Aspose.Slides の動作に制約をもたらす可能性があります。

- **RegistryPermission** が利用できません。これにより、ドキュメントのレンダリング時にインストール済みフォントを列挙するためにレジストリへアクセスできなくなります。  
- **FileIOPermission** が制限されます。アプリケーションの仮想ディレクトリ階層内のファイルしかアクセスできません。これにより、エクスポート操作中にフォントが読み取れない可能性があります。

以上の理由から、Aspose.Slides は **Full Trust** 権限で実行することを強く推奨します。**Medium trust** を使用すると、特定のタスク実行時にライブラリ機能（例: レンダリング）が正常に動作しないことがあります。

## **macOS**

NuGet は、macOS 上で .NET 用 Aspose.Slides をダウンロードおよびインストールする最も簡単な方法を提供します。

**Install Prerequisite**

`System.Drawing` 名前空間は macOS で動作が異なるため、mono-libgdiplus をインストールする必要があります。

> .NET 5 以前のバージョンでは、[System.Drawing.Common](https://www.nuget.org/packages/System.Drawing.Common/) NuGet パッケージは Windows、Linux、macOS で動作します。ただし、プラットフォーム間で差異があります。Linux と macOS では、GDI+ 機能は [libgdiplus](https://www.mono-project.com/docs/gui/libgdiplus/) ライブラリで実装されています。このライブラリは多くの Linux ディストリビューションにデフォルトでインストールされておらず、Windows および macOS の GDI+ のすべての機能をサポートしていません。また、libgdiplus が全く利用できないプラットフォームもあります。Linux と macOS で System.Drawing.Common パッケージの型を使用するには、libgdiplus を別途インストールする必要があります。詳細は [Install .NET on Linux](https://docs.microsoft.com/en-us/dotnet/core/install/linux) または [Install .NET on macOS](https://docs.microsoft.com/en-us/dotnet/core/install/macos#libgdiplus) を参照してください。

mac に mono-libgdiplus を別途インストールする方法は、.NET ドキュメントの [this article](https://docs.microsoft.com/en-us/dotnet/core/install/macos#libgdiplus) を参照してください。

### **Install Aspose.Slides**

1. Visual Studio を開きます。  
2. 簡単なコンソール アプリを作成するか、既存のプロジェクトを開きます。  
3. **Project** > **Manage NuGet Packages...** を選択します。  
   ![path-to-nuget-macos](path-to-nuget-macos.png)
4. テキスト フィールドに *Aspose.Slides* と入力します。  
5. **Aspose.Slides for .NET** をクリックし、続いて **Add Package** をクリックします。  
6. 簡単なコード スニペットを追加します。  
   * [this page](/slides/ja/net/create-presentation/) のコードをコピーできます。  
7. アプリを実行します。  
8. プロジェクトの *folder/bin/Debug/presentation_file_name* を開きます。

## **FAQ**

**Is there a free version or trial limitation?**

はい、デフォルトでは Aspose.Slides は評価モードで実行され、透かしが表示されるほか、その他の制限がある場合があります。制限を解除するには、有効な [license](/slides/ja/net/licensing/) を適用する必要があります。