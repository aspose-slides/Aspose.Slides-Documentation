---
title: Aspose.Slides for C++
second_title: Aspose.Slides for C++
type: docs
weight: 30
url: /ja/cpp/
keywords:
- ドキュメント
- プレゼンテーション処理
- プレゼンテーション変換
- PowerPoint
- OpenDocument
- C++
- Aspose.Slides
description: "ここから始めましょう: Aspose.Slides for C++ をインストールし、最初のプレゼンテーションを作成し、一般的なタスクのガイド、API リファレンス、サポートを見つけてください。"
is_root: true
---
<img src="home_1.png" alt="Aspose.Slides for C++" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for C++ は、Microsoft PowerPoint や Office Automation を使用せずに、PowerPoint および OpenDocument プレゼンテーションの作成、読み取り、編集、変換を行うネイティブ C++ ライブラリです。

マクロ対応やテンプレートのバリアントを含む PPT、PPTX、PPS、POT、ODP を読み込み・保存でき、PDF、XPS、HTML、SVG、TIFF、Markdown、画像へエクスポートします。

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>はじめに</b></p>
<hr>
<p>開始ガイド</p>
<ul>
<li><a href="/slides/ja/cpp/installation/">インストール</a></li>
<li><a href="/slides/ja/cpp/create-presentation/">最初のプレゼンテーションを作成</a></li>
<li><a href="/slides/ja/cpp/getting-started/">はじめにガイド</a></li>
</ul>
<p>評価</p>
<ul>
<li><a href="/slides/ja/cpp/supported-file-formats/">サポートされているファイル形式</a></li>
<li><a href="/slides/ja/cpp/evaluate-aspose-slides/">トライアルの制限</a></li>
<li><a href="/slides/ja/cpp/licensing/">ライセンス</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Slides でビルド</b></p>
<hr>
<p>共通タスク</p>
<ul>
<li><a href="/slides/ja/cpp/open-presentation/">プレゼンテーションを開く</a></li>
<li><a href="/slides/ja/cpp/save-presentation/">プレゼンテーションを保存</a></li>
<li><a href="/slides/ja/cpp/convert-powerpoint-to-pdf/">PDF に変換</a></li>
<li><a href="/slides/ja/cpp/convert-slide/">スライドを画像としてレンダリング</a></li>
<li><a href="/slides/ja/cpp/manage-text/">テキストと図形を編集</a></li>
</ul>
<p>Slides ワークフロー</p>
<ul>
<li><a href="/slides/ja/cpp/powerpoint-charts/">チャート</a></li>
<li><a href="/slides/ja/cpp/powerpoint-animation/">アニメーション</a></li>
<li><a href="/slides/ja/cpp/manage-media-files/">オーディオとビデオ</a></li>
<li><a href="/slides/ja/cpp/presentation-design/">スライド デザイン</a></li>
<li><a href="/slides/ja/cpp/merge-presentation/">プレゼンテーションを結合</a></li>
</ul>
<p>例</p>
<ul>
<li><a href="/slides/ja/cpp/examples/">スライド要素別の例</a></li>
<li><a href="https://github.com/aspose-slides/Aspose.Slides-for-C">GitHub 上の例</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>リファレンス &amp; サポート</b></p>
<hr>
<p>リファレンス</p>
<ul>
<li><a href="https://reference.aspose.com/slides/cpp/">API リファレンス</a></li>
<li><a href="https://releases.aspose.com/slides/cpp/release-notes/">リリース ノート</a></li>
<li><a href="/slides/ja/cpp/known-issues/">既知の問題</a></li>
<li><a href="https://products.aspose.com/slides/cpp/">製品ページ</a></li>
<li><a href="https://releases.aspose.com/slides/cpp/">ダウンロード</a></li>
</ul>
<p>サポート</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">無料サポートフォーラム</a></li>
<li><a href="https://helpdesk.aspose.com/">有料サポートヘルプデスク</a></li>
</ul>
</div>
</div>

------

## **最初のプレゼンテーション**

Windows では、Visual Studio で C++ **Console App** プロジェクトを作成し、Package Manager Console (**ツール** > **NuGet パッケージ マネージャー** > **Package Manager Console**) で NuGet パッケージをインストールします：

```powershell
Install-Package Aspose.Slides.Cpp
```

Linux では、Linux ZIP パッケージをダウンロードし、[インストール](/slides/ja/cpp/installation/#linux) に記載されている CMake プロジェクトを設定します。

次に、このコードをプログラムのメイン ソース ファイルとして使用します。テキスト ボックスが 1 つ含まれたプレゼンテーションを作成し、保存します：

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/ITextFrame.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

int main()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);
    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 400, 100);
    shape->get_TextFrame()->set_Text(u"Hello, Aspose.Slides!");
    presentation->Save(u"hello.pptx", SaveFormat::Pptx);
    presentation->Dispose();
    return 0;
}
```

Windows で実行するには、ツールバーで **x64** プラットフォームを選択し、**Ctrl+F5** を押します。Linux では、プロジェクト フォルダーに *main.cpp* として保存し、そこでビルドして実行します：

```bash
cmake -S . -B build -DCMAKE_BUILD_TYPE=Release
cmake --build build
./build/hello
```

このプログラムはテキスト ボックスを含む 1 枚のスライドを持つ *hello.pptx* を保存します。ライセンスがない場合、保存されたファイルには評価用の透かしが付加されます — 詳細は [ライセンス](/slides/ja/cpp/licensing/) を参照してください。プレゼンテーションの作成や内容の入力方法の詳細は、[プレゼンテーションの作成](/slides/ja/cpp/create-presentation/) をご覧ください。