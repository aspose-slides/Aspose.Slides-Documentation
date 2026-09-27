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
- NuGet
- CMake
- Windows
- Linux
- PowerPoint
- OpenDocument
- プレゼンテーション
- C++
- Aspose.Slides
description: "Visual Studio の NuGet から Windows に Aspose.Slides for C++ をインストールするか、CMake を使用した ZIP パッケージから Linux にインストールし、最初のプログラムでインストールを確認します。"
---
## **概要**

Aspose.Slides for C++ は 2 つの形態で配布されています:

| 形態 | 使用対象 | 取得場所 |
|---|---|---|
| NuGet パッケージ: [Aspose.Slides.Cpp](https://www.nuget.org/packages/Aspose.Slides.Cpp/) (64 ビット) および [Aspose.Slides.Cpp.x86](https://www.nuget.org/packages/Aspose.Slides.Cpp.x86/) (32 ビット) | Windows の Visual Studio C++ プロジェクト | NuGet |
| Windows、Linux、macOS 用 ZIP パッケージ | NuGet を使用しないビルド（例: CMake プロジェクト） | [ダウンロード ページ](https://releases.aspose.com/slides/cpp/) |

本稿では、Windows の Visual Studio で NuGet パッケージをインストールする方法と、Linux で CMake を使用して ZIP パッケージを利用する方法を示します。どちらの方法でも、最終的には [Create Presentations](/slides/ja/cpp/create-presentation/) の最初のサンプルをビルドして実行することで確認します。

## **Windows**

Windows では、Visual Studio C++ プロジェクトに NuGet パッケージを追加します。パッケージは依存関係である CodePorting.Translator.Cs2Cpp.Framework もインストールし、プログラムが必要とする DLL をビルド出力フォルダーにコピーします。

ビルド対象のプラットフォームに合わせてパッケージを選択します: x64 用は **Aspose.Slides.Cpp**、Win32 (x86) 用は **Aspose.Slides.Cpp.x86**。Aspose.Slides.Cpp パッケージは Win32 ビルドには適用されないため、ヘッダーが見つからなくなります。

Windows 用 ZIP パッケージは [ダウンロード ページ](https://releases.aspose.com/slides/cpp/) からも入手できます。

### **方法 1: NuGet パッケージ マネージャーから Aspose.Slides をインストールまたは更新**

1. Microsoft Visual Studio を開きます。
2. C++ の **Console App** プロジェクトを作成するか、既存のプロジェクトを開きます。
3. **Solution Explorer** でプロジェクトを右クリックし、**Manage NuGet Packages** を選択します（または **Project** > **Manage NuGet Packages**）。
4. **Browse** タブで *Aspose.Slides.Cpp* を検索します。  
   ![NuGet パッケージ マネージャーで Aspose.Slides.Cpp を検索](installation_1.png)
5. **Aspose.Slides.Cpp**（32 ビットビルドの場合は **Aspose.Slides.Cpp.x86**）をクリックし、**Install** を選択します。  
   * 既に Aspose.Slides がインストールされていて更新したい場合は **Update** をクリックします。

パッケージがダウンロードされ、プロジェクトに参照として追加されます。

### **方法 2: パッケージ マネージャー コンソールから Aspose.Slides をインストールまたは更新**

1. Microsoft Visual Studio を開きます。
2. C++ の **Console App** プロジェクトを作成するか、既存のプロジェクトを開きます。
3. **Tools** > **NuGet Package Manager** > **Package Manager Console** を開きます。  
   ![パッケージ マネージャー コンソールを開く](installation_2.png)
4. 次のコマンドを実行します:

   ```powershell
   Install-Package Aspose.Slides.Cpp
   ```

   32 ビット (Win32) ビルドの場合は、代わりに x86 パッケージをインストールします:

   ```powershell
   Install-Package Aspose.Slides.Cpp.x86
   ```

   ![Install-Package コマンドの実行](installation_3.png)

インストールが完了すると確認メッセージが表示されます。パッケージは [Aspose EULA](https://about.aspose.com/legal/eula) の下で配布されています。  
![インストール完了メッセージ](installation_4.png)

パッケージを更新するには、Package Manager Console で `Update-Package Aspose.Slides.Cpp`（または `Update-Package Aspose.Slides.Cpp.x86`）を実行します。

### **インストールの確認**

1. プロジェクトのメイン *.cpp* ファイル（`main` を含むファイル）の内容を、[Create Presentations](/slides/ja/cpp/create-presentation/) の最初のサンプルに置き換えます。
2. ツールバーで **x64** プラットフォーム、または **x86**（Aspose.Slides.Cpp.x86 をインストールした場合）を選択します。
3. **Ctrl+F5** を押してビルドおよび実行します。

プログラムはプロジェクト フォルダーに *hello.pptx* を保存します。これは Visual Studio がプログラムを実行したときのデフォルト作業ディレクトリです。

## **Linux**

Linux では、CMake と共に Linux 用 ZIP パッケージを使用します。パッケージには Aspose.Slides ライブラリ、依存関係の CodePorting.Translator.Cs2Cpp.Framework、そしてそれぞれの CMake 設定ファイルが含まれています。ライブラリは glibc 2.23 以降がインストールされた x86_64 Linux 用にビルドされています。

1. C++ コンパイラ、make、CMake、unzip、そして Aspose.Slides が依存する fontconfig ライブラリをインストールします。Debian/Ubuntu 系の場合:

   ```bash
   sudo apt-get update && sudo apt-get install -y g++ make cmake unzip libfontconfig1
   ```

2. プロジェクト フォルダーを作成し、そこへ移動します:

   ```bash
   mkdir hello-slides
   cd hello-slides
   ```

3. [ダウンロード ページ](https://releases.aspose.com/slides/cpp/) から Linux 用 ZIP (**Aspose.Slides for C++ Linux**) をプロジェクト フォルダーにダウンロードし、*aspose-slides-cpp* サブフォルダーに解凍します:

   ```bash
   unzip aspose-slides-cpp-linux-*.zip -d aspose-slides-cpp
   ```

4. プロジェクト フォルダーに *CMakeLists.txt* という名前のファイルを作成し、以下の内容を貼り付けます:

   ```cmake
   cmake_minimum_required(VERSION 3.13)
   project(HelloSlides CXX)

   set(CMAKE_CXX_STANDARD 14)
   set(CMAKE_CXX_STANDARD_REQUIRED ON)

   set(ASPOSE_SLIDES_DIR "${CMAKE_CURRENT_SOURCE_DIR}/aspose-slides-cpp")
   find_package(CodePorting.Translator.Cs2Cpp.Framework REQUIRED CONFIG PATHS "${ASPOSE_SLIDES_DIR}" NO_DEFAULT_PATH)
   find_package(Aspose.Slides.Cpp REQUIRED CONFIG PATHS "${ASPOSE_SLIDES_DIR}" NO_DEFAULT_PATH)

   add_executable(hello main.cpp)
   target_link_libraries(hello PRIVATE Aspose.Slides.Cpp)
   ```

   2 つの `find_package` 呼び出しは、解凍したパッケージから CMake 設定ファイルを読み込みます。Framework が先に見つかるのは、Aspose.Slides がそれに依存しているためです。`Aspose.Slides.Cpp` ターゲットをリンクすると、インクルード フォルダーと両方のライブラリがビルドに追加されます。

5. [Create Presentations](/slides/ja/cpp/create-presentation/) の最初のサンプルを *main.cpp* としてプロジェクト フォルダーに保存します。
6. プログラムをビルドして実行します:

   ```bash
   cmake -S . -B build -DCMAKE_BUILD_TYPE=Release
   cmake --build build
   ./build/hello
   ```

プログラムは現在のフォルダーに *hello.pptx* を保存します。CMake は実行ファイルにライブラリのパスを書き込むため、*aspose-slides-cpp* フォルダーをそのまま残しておけば `LD_LIBRARY_PATH` を設定する必要はありません。

プレゼンテーションで使用するフォント、または適切な代替フォントはシステムにインストールしておく必要があります。これがないと、スライドを PDF や画像に変換した際にテキストが正しく描画されません。

## **FAQ**

**無料版やトライアルの制限はありますか？**

はい。ライセンスがない場合、Aspose.Slides は評価モードで動作し、保存するすべてのスライドに評価用透かしが付加され、プレゼンテーションから読み取ったテキストが切り捨てられます。これらの制限を解除するには、有効な [ライセンス](/slides/ja/cpp/licensing/) を適用してください。

**コンパイラが *DOM/Presentation.h* を開けないと報告するのはなぜですか？**

インストールしたパッケージがビルド対象のプラットフォームと一致していません。Aspose.Slides.Cpp は x64 ビルドのみ、Aspose.Slides.Cpp.x86 は Win32 ビルドのみ適用されます。Visual Studio で対象プラットフォームを合わせるか、別のパッケージをインストールしてください。