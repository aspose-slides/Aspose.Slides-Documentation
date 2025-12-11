---
title: Qt で PowerPoint ドキュメントを操作する
type: docs
weight: 60
url: /ja/cpp/work-with-powerpoint-documents-in-qt/
keywords:
- Qt Creator
- Qt アプリケーション
- クロスプラットフォーム
- PowerPoint
- OpenDocument
- プレゼンテーション
- C++
- Aspose.Slides
description: "Qt Creator と Visual Studio を使用して Aspose.Slides for C++ を活用し、クロスプラットフォームアプリで PowerPoint および OpenDocument のプレゼンテーションを作成、ロード、編集します。"
---

Qt は C++ ベースのクロスプラットフォーム アプリケーション開発フレームワークで、デスクトップ、モバイル、組み込みシステム向けのさまざまなアプリケーション開発に広く使用されています。Aspose.Slides for C++ を Qt に統合することで、Qt アプリケーション内で PowerPoint ドキュメントの作成や操作が可能になります。

## **Qt Creator で Aspose.Slides for C++ を使用する**

Qt アプリケーションで Aspose.Slides for C++ を使用するには、[downloads](https://downloads.aspose.com/slides/cpp) セクションから API の最新バージョンをダウンロードします。API をダウンロードしたら、Qt Creator または Visual Studio に C++ ライブラリを統合できます。

Qt Creator で開発した Qt コンソール アプリケーションに Aspose.Slides for C++ ライブラリを統合して使用する手順は以下の通りです。

- Qt Creator を開き、*Qt Console Application* を新規作成します。

![qt_console_application](qt-console-application.png)

- *Build System* ドロップダウンリストから QMake オプションを選択します。

![qt_console_application_qmake](qt-console-application-qmake.png)

- 適切なキットを選択し、ウィザードを完了します。
- Aspose.Slides for C++ の展開パッケージから aspose-slides-cpp-21.02 フォルダーをプロジェクトのルートにコピーします。

![lib_files](aspose.slides-lib-files.png)

- lib と include フォルダーへのパスを追加するには、左側パネルのプロジェクトを右クリックし、*Add Library* を選択します。

![qt_add_library](qt_add_library.png)

- External Library オプションを選択し、include と lib フォルダーのパスを 1 つずつ参照します。

![todo:image_alt_text](qt-add-external-library.png)

- 完了すると、.pro プロジェクト ファイルに以下のエントリが含まれます。

![qt_pro_file.png](qt-pro-file.png)

- アプリケーションをビルドすれば、統合は完了です。  

{{% alert color="primary" %}}
Note: 詳細については、[full demo project](https://github.com/aspose-slides/Aspose.Slides-for-C/tree/master/QtDemos/QtCreator/Qt_AsposeSlides_QMake) を参照してください。
{{% /alert %}}

## **Visual Studio で Qt アプリケーション内で Aspose.Slides for C++ を使用する**

Visual Studio を使用して Qt アプリケーションを開発するには、[Qt Visual Studio Tools](https://marketplace.visualstudio.com/items?itemName=TheQtCompany.QtVisualStudioTools-19123) をインストールする必要があります。インストールが完了したら、[downloads](https://downloads.aspose.com/slides/cpp) セクションから API の最新バージョンをダウンロードし、以下の手順に従います。

- Microsoft Visual Studio を開き、*Qt Console Application* を新規作成します。

![VS_Console_Application.png](vs-console-application.png)

- 適切なキットを選択し、ウィザードを完了します。
- Aspose.Slides for C++ ライブラリを統合して使用するには、プロジェクトを右クリックし、*Manage NuGet Packages...* を選択します。

![VS_Manage_NuGet_Package.png](vs-manage-nuget-package.png)

- 必要な *Aspose.Slides.Cpp* パッケージを検索してインストールします。

![VS_Find_Nuget.png](vs-find-nuget.png)

- プロジェクトをビルドすれば、統合は完了です。  

{{% alert color="primary" %}}
Note: 詳細については、[full demo project](https://github.com/aspose-slides/Aspose.Slides-for-C/tree/master/QtDemos/Visual%20Studio/Qt_AsposeSlides_VS) を参照してください。
{{% /alert %}}