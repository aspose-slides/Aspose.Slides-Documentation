---
title: インストール
type: docs
weight: 70
url: /net/installation/
keywords: "Aspose.Slidesのダウンロード, Aspose.Slidesのインストール, Aspose.Slidesのインストール, Windows, macOS, .NET"
description: "WindowsまたはmacOSにAspose.Slides for .NETをインストールする"
---

## **Windows**
NuGetは、PCにASP.NET用のAspose APIをダウンロードしてインストールする最も簡単な方法を提供します。

### **方法 1: NuGetパッケージマネージャーからAspose.Slidesをインストールまたは更新する**

1. Microsoft Visual Studioを開きます。
2. シンプルなコンソールアプリを作成するか、既存のプロジェクトを開きます。
3. **ツール** > **NuGetパッケージマネージャー**に進みます。
4. **ブラウズ**の下で、テキストフィールドに*Aspose Slides*を検索します。
{{% image img="installation_1.png" alt="Aspose.SlidesのNuGetパッケージマネージャーからのインストール - 1" %}}
5. **Aspose.Slides.NET**をクリックし、その後**インストール**をクリックします。
   * 既にAspose.Slidesをインストールしている場合は、**更新**をクリックします。

選択したAPIがダウンロードされ、プロジェクトに参照されます。

### **方法 2: パッケージマネージャーコンソールを介してAspose.Slidesをインストールまたは更新する**

これは、パッケージマネージャーコンソールを介して[Aspose.Slides API](https://www.nuget.org/packages/Aspose.Slides.NET/)を参照する方法です：

1. Microsoft Visual Studioを開きます。
2. シンプルなコンソールアプリを作成するか、既存のプロジェクトを開きます。
3. **ツール** > **ライブラリパッケージマネージャー** > **パッケージマネージャーコンソール**に進みます。
![todo:image_alt_text](installation_2.png)
4. このコマンドを実行します： `Install-Package Aspose.Slides.NET`
![todo:image_alt_text](installation_3.png)
最新の完全リリースがアプリケーションにインストールされます。

* 代わりに、コマンドに`-prerelease`のサフィックスを追加して、最新のリリース（ホットフィックスを含む）もインストールされるように指定できます。

 **Aspose.Slides.NETのインストール中**のヒントがウィンドウの下部に表示されます。
![todo:image_alt_text](installation_4.png)

ダウンロードが完了すると、一部の確認メッセージが表示されます。

[Aspose EULA](https://about.aspose.com/legal/eula)に慣れていない場合は、URLに参照されたライセンスを読むことをお勧めします。
![todo:image_alt_text](installation_5.png)

アプリケーションでは、Aspose.Slidesが正常に追加および参照されたことが表示されるはずです。
![todo:image_alt_text](installation_6.png)

パッケージマネージャーコンソールで、`Update-Package Aspose.Slides.NET`コマンドを実行してAspose.Slidesパッケージの更新を確認できます。更新（見つかった場合）は自動的にインストールされます。最新のリリースを更新するために`-prerelease`サフィックスを使用することもできます。
#### **共有サーバー環境での実行時の考慮事項**
Aspose .NETコンポーネントはすべて**フル信頼**権限セットで実行することを強くお勧めします。なぜなら、Asposeコンポーネントが時々、仮想ディレクトリ以外の場所にあるレジストリ設定やファイルにアクセスする必要があるからです。たとえば、Asposeコンポーネントがフォントを読み取る必要がある場合です。

さらに、Aspose.NETコンポーネントは、コア.NETシステムクラスに基づいており、その中のいくつかのクラスは特定のケースでの操作にフル信頼権限を必要とします。

異なる会社の複数のアプリケーションをホストするインターネットサービスプロバイダーは、主にミディアムトラストセキュリティレベルを強制します。.NET 2.0の場合、このようなセキュリティレベルはAspose.Slidesの操作に影響を与える制約を引き起こす可能性があります：

- **RegistryPermission**は利用できません。これは、ドキュメントをレンダリングする際にインストールされたフォントを列挙するために必要なレジストリにアクセスできないことを意味します。
- **FileIOPermission**が制限されています。これは、アプリケーションの仮想ディレクトリ階層内のファイルにのみアクセスできることを意味します。これにより、エクスポート操作中にフォントが読み取れない可能性もあります。

上記の理由から、Aspose.Slidesを**フル信頼**の権限で実行することを強くお勧めします。**ミディアムトラスト**を使用すると、一部のライブラリ機能（例えばレンダリング）が特定のタスクを実行する際に機能しない場合があります。

## **macOS**

NuGetは、macにAspose.Slides for .NETをダウンロードしてインストールする最も簡単な方法を提供します。

**前提条件のインストール**

`System.Drawing`名前空間はmacOSで異なる動作をするため、mono-libgdiplusをインストールする必要があります。

> .NET 5以前のバージョンでは、[System.Drawing.Common](https://www.nuget.org/packages/System.Drawing.Common/) NuGetパッケージはWindows、Linux、macOSで動作します。ただし、プラットフォームによる違いがあります。LinuxおよびmacOSでは、GDI+機能は[libgdiplus)](https://www.mono-project.com/docs/gui/libgdiplus/)ライブラリによって実装されています。このライブラリは、ほとんどのLinuxディストリビューションにデフォルトでインストールされておらず、WindowsおよびmacOSのGDI+のすべての機能をサポートしているわけではありません。libgdiplusがまったく利用できないプラットフォームもあります。LinuxおよびmacOSでSystem.Drawing.Commonパッケージの型を使用するには、libgdiplusを別途インストールする必要があります。詳細については、[Linuxに.NETをインストール](https://docs.microsoft.com/en-us/dotnet/core/install/linux)または[macOSに.NETをインストール](https://docs.microsoft.com/en-us/dotnet/core/install/macos#libgdiplus)を参照してください。

macでmono-libgdiplusを個別にインストールするには、.NETドキュメントの[この記事](https://docs.microsoft.com/en-us/dotnet/core/install/macos#libgdiplus)を参照してください。

### **Aspose.Slidesのインストール**

1. Visual Studioを開きます。
2. シンプルなコンソールアプリを作成するか、既存のプロジェクトを開きます。
3. **プロジェクト** > **NuGetパッケージの管理...**に進みます。
   ![path-to-nuget-macos](path-to-nuget-macos.png)
4. テキストフィールドに*Aspose.Slides*と入力します。
5. **Aspose.Slides for .NET**をクリックし、その後**パッケージを追加**をクリックします。
6. シンプルなコードスニペットを追加します。
   * [このページ](/slides/net/create-presentation/)のコードをコピーできます。
7. アプリを実行します。
8. プロジェクトの*folder/bin/Debug/presentation_file_name*を開きます。