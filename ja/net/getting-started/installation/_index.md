---
title: インストール
type: docs
weight: 70
url: /ja/net/installation/
keywords:
- Aspose.Slides のインストール
- Aspose.Slides のダウンロード
- Aspose.Slides の使用
- Aspose.Slides のインストール手順
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Windows、Linux、macOS で NuGet から .NET 用 Aspose.Slides をインストールします：2 つのパッケージから選択し、.NET CLI または Visual Studio でいずれかを追加し、Linux の前提条件をインストールします。"
---
## **概要**

このガイドでは、Windows、Linux、macOS のプロジェクトに Aspose.Slides for .NET を追加する方法を説明します。Aspose.Slides は NuGet を通じて配布されています。任意の OS で .NET CLI を使用して追加でき、Windows の Visual Studio では NuGet パッケージ マネージャーまたはパッケージ マネージャー コンソールでも追加できます。また、2 つの NuGet パッケージのどちらを選択すべきか、および Linux が追加で必要とするものについても説明します。

インストール前に、[システム要件](/slides/ja/net/system-requirements/)でサポートされている OS、.NET 実装、および追加の依存関係を確認してください。

## **パッケージの選択**

Aspose.Slides for .NET は 2 つの NuGet パッケージとして公開されています。どちらも同じ Aspose.Slides の名前空間とクラスを提供するため、コードは変更不要です。違うのはパッケージ参照とプラットフォーム要件だけです。

| パッケージ | 対象 | 追加要件 |
|---|---|---|
| [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) | Windows および .NET Framework アプリケーション | Linux と macOS: `libgdiplus` ライブラリと、アプリケーション起動時に有効にする `System.Drawing.EnableUnixSupport` スイッチ |
| [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/) | Windows、Linux、macOS の .NET 6 以降 | Linux: まだインストールされていない場合は `fontconfig` ライブラリ |

どちらを選べばよいか分からない場合は、Windows では Aspose.Slides.NET、Linux と macOS では Aspose.Slides.NET6.CrossPlatform を使用してください。Alpine Linux や glibc が 2.23 未満 (x64) または 2.39 未満 (ARM64) の Linux システムでは、Aspose.Slides.NET を使用します。[システム要件](/slides/ja/net/system-requirements/) に各パッケージのサポート対象プラットフォームが記載されています。

## **.NET CLI を使用したインストール**

以下の手順は Windows、Linux、macOS すべてで .NET SDK 6 以降を使用して動作します。コンソール アプリケーションを作成します:

```bash
dotnet new console -n HelloSlides
cd HelloSlides
```

次に、対象プラットフォーム用のパッケージを追加します。プロジェクトには 2 つのパッケージのどちらか一方だけを追加してください。

- Windows: `dotnet add package Aspose.Slides.NET`
- Linux と macOS: `dotnet add package Aspose.Slides.NET6.CrossPlatform`（Linux では事前に必要なものをインストールしてください。詳細は [Linux](#linux) を参照）

パッケージが正しく動作するか確認するには、*Program.cs* の内容を [プレゼンテーションの作成](/slides/ja/net/create-presentation/) にある最初のサンプルに置き換え、`dotnet run` を実行します。*hello.pptx* がプロジェクト フォルダーに保存されます。

## **Windows**

### **方法 1: NuGet パッケージ マネージャーから Aspose.Slides をインストールまたは更新**

1. Microsoft Visual Studio を開きます。  
2. コンソール アプリを作成するか、既存のプロジェクトを開きます。  
3. **Solution Explorer** でプロジェクトを右クリックし、**Manage NuGet Packages** を選択します（または **Project** > **Manage NuGet Packages**）。  
4. **Browse** タブで *Aspose.Slides* を検索します。  
{{% image img="installation_1.png" alt="Aspose.Slides Installation from NuGet Package Manager - 1" %}}  
5. **Aspose.Slides.NET** をクリックし、**Install** を選択します。  
   * すでに Aspose.Slides がインストール済みで更新したい場合は **Update** をクリックしてください。

パッケージがダウンロードされ、プロジェクトに参照として追加されます。

### **方法 2: パッケージ マネージャー コンソールから Aspose.Slides をインストールまたは更新**

パッケージ マネージャー コンソールで [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) パッケージを参照する手順は次のとおりです。

1. Microsoft Visual Studio を開きます。  
2. コンソール アプリを作成するか、既存のプロジェクトを開きます。  
3. **Tools** > **NuGet Package Manager** > **Package Manager Console** を選択します。  
![パッケージ マネージャー コンソールを開く](installation_2.png)  
4. 次のコマンドを実行します: `Install-Package Aspose.Slides.NET`  
![Install-Package コマンドの実行](installation_3.png)  
最新リリースがプロジェクトにインストールされます。

ウィンドウ下部に **Installing Aspose.Slides.NET** メッセージが表示されます。  
![パッケージ マネージャー コンソールのインストール進行状況](installation_4.png)

ダウンロードが完了すると確認メッセージが表示されます。パッケージは [Aspose EULA](https://about.aspose.com/legal/eula) に基づいて配布されます。  
![インストール完了メッセージ](installation_5.png)

Aspose.Slides がプロジェクトに追加され、参照されます。  
![プロジェクトに参照された Aspose.Slides](installation_6.png)

パッケージを更新するには、パッケージ マネージャー コンソールで `Update-Package Aspose.Slides.NET` を実行してください。

## **Linux**

上記の .NET CLI 手順を使用します。パッケージを選択し、ディストリビューションのパッケージ マネージャーで前提条件をインストールしてください。Debian と Ubuntu の例:

- **Aspose.Slides.NET6.CrossPlatform**: `fontconfig` をインストールします。

  ```bash
  sudo apt-get update && sudo apt-get install -y libfontconfig1
  dotnet add package Aspose.Slides.NET6.CrossPlatform
  ```

- **Aspose.Slides.NET**: `libgdiplus` をインストールし、Aspose.Slides を使用する前に System.Drawing の Unix サポートを有効にします。

  ```bash
  sudo apt-get update && sudo apt-get install -y libgdiplus
  dotnet add package Aspose.Slides.NET
  ```

  アプリケーションの開始時に次のステートメントを追加します（Aspose.Slides の呼び出しの前）。トップレベルステートメントを使用した *Program.cs* の場合は、`using` ディレクティブの後に記述してください。

  ```c#
  System.AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
  ```

  Alpine Linux や、glibc が古くて Aspose.Slides.NET6.CrossPlatform を使用できないシステムではこのパッケージを使用します。

プレゼンテーションで使用するフォント、または適切な代替フォントはシステムにインストールしておく必要があります。テキストが正しくレンダリングされます。[システム要件](/slides/ja/net/system-requirements/) では Alpine Linux 向けに必要なパッケージ（フォントを含む）を説明しています。

## **macOS**

上記の .NET CLI 手順を **Aspose.Slides.NET6.CrossPlatform** パッケージで実行します。このパッケージは Intel (x86_64) と Apple silicon (ARM64) の両方の Mac をサポートしています。

```bash
dotnet add package Aspose.Slides.NET6.CrossPlatform
```

## **FAQ**

**無料版や試用版に制限はありますか？**

はい。ライセンスがない場合、Aspose.Slides は評価モードで動作し、保存するすべてのスライドに評価用透かしが追加され、プレゼンテーションから読み取ったテキストが切り詰められます。これらの制限を解除するには、有効な [ライセンス](/slides/ja/net/licensing/) を適用してください。