---
title: インストール
type: docs
weight: 70
url: /ja/cpp/installation/
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
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を迅速にインストールする方法を学びます。ステップバイステップのガイド、システム要件、コードサンプル — 本日から PowerPoint プレゼンテーションの作成を開始しましょう！"
---

## **Windows**
NuGet は、PC 用の Aspose API for C++ をダウンロードしてインストールする最も簡単な方法を提供します。

### **オプション 1: NuGet パッケージ マネージャーから Aspose.Slides for C++ をインストールまたは更新する**

1. Microsoft Visual Studio を開きます。  
2. 簡単なコンソール アプリを作成するか、既存のプロジェクトを開きます。  
3. **Tools** > **NuGet package manager** を選択します。  
4. **Browse** でテキスト フィールドに *Aspose.Slides.Cpp* と入力します。

![todo:image_alt_text](installation_1.png)

3. 必要なバージョンの **Aspose.Slides.Cpp** をクリックし、**Install** をクリックします。  
   * すでにインストール済みで更新したい場合は **Update** をクリックします。

選択した API がダウンロードされ、プロジェクトに参照として追加されます。

### **オプション 2: パッケージ マネージャー コンソールから Aspose.Slides をインストールまたは更新する**

パッケージ マネージャー コンソールを使用して [Aspose.Slides API](https://www.nuget.org/packages/Aspose.Slides.Cpp/) を参照するには、次の手順を実行します。

1. Visual Studio でソリューション/プロジェクトを開きます。

1. **Tools** > **NuGet Package Manager** > **Package Manager Console** を選択します。

   パッケージ マネージャー コンソールが開きます。

![todo:image_alt_text](installation_2.png)

4. 次のコマンドを入力します: `Install-Package Aspose.Slides.Cpp`  
> x86 バージョンをインストールする場合は、Aspose.Slides.Cpp.x86 パッケージを使用します: `Install-Package Aspose.Slides.Cpp.x86`

5. Enter キーを押します。

   最新のフル リリースがアプリケーションにインストールされます。

   * 代わりに、コマンドに `-prerelease` サフィックスを付けて、最新リリース（ホットフィックスを含む）をインストールすることもできます。

![todo:image_alt_text](installation_3.png)

​	ダウンロードが完了すると、いくつかの確認メッセージが表示されます。

![todo:image_alt_text](installation_4.png)

[Aspose EULA](https://about.aspose.com/legal/eula) に詳しくない場合は、URL に記載されているライセンスを確認してください。

Package Manager Console で `Update-Package Aspose.Slides.Cpp` コマンドを実行すると、Aspose.Slides パッケージの更新を確認できます。更新が見つかると自動的にインストールされます。`-prerelease` サフィックスを使用して最新リリースを更新することも可能です。


### **Include と lib フォルダーの使用**
1. [Download](https://downloads.aspose.com/slides/cpp) から最新の Aspose.Slides for C++ バージョンを取得します。  
2. フォルダーを本番環境に展開します。  
3. Aspose.Slides for C++ を使用するために、プロジェクトで Include と lib フォルダーを参照します。

## **FAQ**

**無料版や試用版の制限はありますか？**

はい、デフォルトでは Aspose.Slides は評価モードで実行され、透かしが付加されるほか、その他の制限がある場合があります。制限を解除するには、正当な [license](/slides/ja/cpp/licensing/) を適用する必要があります。