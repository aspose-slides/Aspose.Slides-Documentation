---
title: QtでPowerPoint文書を扱う
type: docs
description: "Aspose.Slides for C++は、Qtアプリケーション内でPowerPoint文書を作成および操作するためにQtに統合できます。"
keywords: "ドキュメントを作成する Qt Creator、ドキュメントをロードする Qt Creator、Qt CreatorでAspose C++を使用する、Aspose C++でドキュメントをロードする、Aspose.Slides C++でサポートされるフォーマットをロードする"
weight: 60
url: /ja/cpp/work-with-powerpoint-documents-in-qt/
---

QtはC++をベースとしたクロスプラットフォームのアプリケーション開発フレームワークであり、デスクトップ、モバイル、および組み込みシステムアプリケーションのさまざまな開発に広く使用されています。Aspose.Slides for C++は、Qtアプリケーション内でPowerPoint文書を作成および操作するためにQtに統合できます。

## Qt Creator内でのAspose.Slides for C++の使用

QtアプリケーションでAspose.Slides for C++を使用するには、[downloads](https://downloads.aspose.com/slides/cpp)セクションからAPIの最新バージョンをダウンロードしてください。APIをダウンロードしたら、C++ライブラリをQt CreatorまたはVisual Studioに統合できます。

Qt Creatorで開発したQtコンソールアプリケーション内でAspose.Slides for C++ライブラリを統合して使用するには、以下の手順に従ってください。

- Qt Creatorを開き、新しい*Qtコンソールアプリケーション*を作成します。

![qt_console_application](qt-console-application.png)

- *ビルドシステム*のドロップダウンリストからQMakeオプションを選択します。

![qt_console_application_qmake](qt-console-application-qmake.png)

- 適切なキットを選択し、ウィザードを完了します。
- Aspose.Slides for C++の解凍したパッケージからaspose-slides-cpp-21.02フォルダーをプロジェクトのルートにコピーします。

![lib_files](aspose.slides-lib-files.png)

- libおよびincludeフォルダへのパスを追加するには、LHSパネルのプロジェクトを右クリックし、*ライブラリを追加*を選択します。

![qt_add_library](qt_add_library.png)

- 外部ライブラリオプションを選択し、libフォルダーへのパスを1つずつブラウズします。

![todo:image_alt_text](qt-add-external-library.png)

- 完了すると、.proプロジェクトファイルに以下のエントリが含まれます：

![qt_pro_file.png](qt-pro-file.png)

- アプリケーションをビルドし、統合が完了しました。

{{% alert color="primary" %}}

注：詳細については、[完全なデモプロジェクト](https://github.com/aspose-slides/Aspose.Slides-for-C/tree/master/QtDemos/QtCreator/Qt_AsposeSlides_QMake)を参照してください。

{{% /alert %}}

## Visual Studio内でのQtアプリケーションでのAspose.Slides for C++の使用

Visual Studioを使用してQtアプリケーションを開発するには、[Qt Visual Studio Tools](https://marketplace.visualstudio.com/items?itemName=TheQtCompany.QtVisualStudioTools-19123)をインストールする必要があります。インストールが完了したら、[downloads](https://downloads.aspose.com/slides/cpp)セクションからAPIの最新バージョンをダウンロードし、以下の手順に従ってください。

- Microsoft Visual Studioを開き、新しい*Qtコンソールアプリケーション*を作成します。

![VS_Console_Application.png](vs-console-application.png)

- 適切なキットを選択し、ウィザードを完了します。
- Aspose.Slides for C++ライブラリを統合して使用するには、プロジェクトを右クリックし、*NuGetパッケージを管理...*を選択します。

![VS_Manage_NuGet_Package.png](vs-manage-nuget-package.png)

- 必要な*Aspose.Slides.Cpp*パッケージを見つけてインストールします。

![VS_Find_Nuget.png](vs-find-nuget.png)

- プロジェクトをビルドし、統合が完了しました。

{{% alert color="primary" %}}

注：詳細については、[完全なデモプロジェクト](https://github.com/aspose-slides/Aspose.Slides-for-C/tree/master/QtDemos/Visual%20Studio/Qt_AsposeSlides_VS)を参照してください。

{{% /alert %}}