---
title: インストール
type: docs
weight: 70
url: /ja/cpp/installation/
keywords: "Aspose.Slidesのダウンロード, Aspose.Slidesのインストール, Aspose.Slidesインストール, Windows, C++"
description: "WindowsでC++用のAspose.Slidesをインストール"
---

## **Windows**
NuGetは、PC上でC++用のAspose APIをダウンロードしてインストールする最も簡単な方法を提供します。

### **オプション1: NuGetパッケージマネージャーからC++用のAspose.Slidesをインストールまたは更新する**

1. Microsoft Visual Studioを開きます。
2. 簡単なコンソールアプリを作成します。または、お好きなプロジェクトを開くことができます。
3. **ツール** > **NuGetパッケージマネージャー**に進みます。
4. **ブラウズ**の下で、テキストフィールドに*Aspose.Slides.Cpp*と入力します。

![todo:image_alt_text](installation_1.png)

3. 必要なバージョンの**Aspose.Slides.Cpp**をクリックし、その後**インストール**をクリックします。
   * Aspose.Slidesの更新を希望する場合（すでにインストールされている場合）は、代わりに**更新**をクリックしてください。

選択したAPIがダウンロードされ、プロジェクトに参照されます。

### **オプション2: パッケージマネージャーコンソールを通じてAspose.Slidesをインストールまたは更新する**

パッケージマネージャーコンソールを使用して[Aspose.Slides API](https://www.nuget.org/packages/Aspose.Slides.Cpp/)を参照するには、次の手順を実行します。

1. Visual Studioでソリューション/プロジェクトを開きます。

1. **ツール** > **NuGetパッケージマネージャー** > **パッケージマネージャーコンソール**に進みます。

   パッケージマネージャーコンソールが開きます。

![todo:image_alt_text](installation_2.png)

4. 次のコマンドを入力します: `Install-Package Aspose.Slides.Cpp` 
> x86バージョンをインストールする場合は、Aspose.Slides.Cpp.x86パッケージを使用します: `Install-Package Aspose.Slides.Cpp.x86`

5. Enterキーを押します。

   最新のフルリリースがアプリケーションにインストールされます。

   * 代わりに、コマンドに`-prerelease`サフィックスを追加して、最新のリリース（ホットフィックスを含む）もインストールされるように指定できます。

![todo:image_alt_text](installation_3.png)

​	ダウンロードが完了すると、いくつかの確認メッセージが表示されるはずです。  

![todo:image_alt_text](installation_4.png)

[Aspose EULA](https://about.aspose.com/legal/eula)に不明な点がある場合は、URLに参照されているライセンスを読むことをおすすめします。

パッケージマネージャーコンソールで、`Update-Package Aspose.Slides.Cpp`コマンドを実行して、Aspose.Slidesパッケージの更新を確認できます。更新（見つかった場合）は自動的にインストールされます。最新のリリースを更新するために`-prerelease`サフィックスを使用することもできます。


### Includeおよびlibフォルダーの使用
1. 最新のC++用のAspose.Slidesのバージョンを[ダウンロード](https://downloads.aspose.com/slides/cpp)します。
1. フォルダーを本番環境に解凍します。
1. C++用のAspose.Slidesを使用するには、プロジェクトでIncludeおよびlibフォルダーを参照します。