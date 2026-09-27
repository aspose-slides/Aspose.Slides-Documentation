---
title: C++ でプレゼンテーションを作成する
linktitle: プレゼンテーションの作成
type: docs
weight: 10
url: /ja/cpp/create-presentation/
keywords:
- プレゼンテーション作成
- 新しいプレゼンテーション
- PPT 作成
- 新しい PPT
- PPTX 作成
- 新しい PPTX
- ODP 作成
- 新しい ODP
- PowerPoint
- OpenDocument
- プレゼンテーション
- C++
- Aspose.Slides
description: "C++ で Aspose.Slides を使用してプレゼンテーションを作成し、PPT、PPTX、ODP ファイルを生成し、OpenDocument のサポートを活かしてプログラムで保存し、信頼できる結果を得られます。"
---
## **概要**

この記事では、Aspose.Slides でプレゼンテーションを作成し、最初のスライドにテキストボックスを追加して、結果をファイルとして保存する方法を示します。最後の短い FAQ では、形式、テンプレート、スライドサイズ、単位、メモリ使用量、スレッド処理、ライセンス、デジタル署名、VBA のサポートに関する一般的な質問を取り上げています。

始める前に、プロジェクトに Aspose.Slides を追加してください。Windows の Visual Studio プロジェクトでは NuGet から、Linux では CMake を使用した ZIP パッケージから追加できます。[インストール](/slides/ja/cpp/installation/)。

## **PowerPoint プレゼンテーションの作成**

プレゼンテーションを作成し、最初のスライドにテキストボックスを配置するには、以下の手順に従ってください:

1. [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) クラスのインスタンスを作成します。新しいプレゼンテーションにはすでに空のスライドが 1 枚含まれています。
2. [Presentation::get_Slide](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_slide/) メソッドを使用してそのスライドを取得し、インデックスは 0 です。
3. [IShapeCollection::AddAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addautoshape/) メソッドで矩形を追加し、[ITextFrame::set_Text](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/set_text/) メソッドでテキストを設定します。
4. [Presentation::Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/) メソッドを使用してプレゼンテーションを PPTX ファイルとして保存します。

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

矩形の左上隅はスライドの左端から 50 ポイント、上端から 50 ポイントの位置にあり、幅は 400 ポイント、高さは 100 ポイントです。プログラムは作業ディレクトリに *hello.pptx* を保存し、矩形とそのテキストを含むスライドが 1 枚作成されます。ライセンスがない場合、Aspose.Slides は保存するすべてのスライドに評価用の透かしを追加します。詳しくは[ライセンス](/slides/ja/cpp/licensing/)を参照してください。

## **FAQ**

### 新しいプレゼンテーションを保存できる形式は何ですか？

以下の形式で保存できます: [PPTX, PPT, and ODP](/slides/ja/cpp/save-presentation/)、また、[PDF](/slides/ja/cpp/convert-powerpoint-to-pdf/)、[XPS](/slides/ja/cpp/convert-powerpoint-to-xps/)、[HTML](/slides/ja/cpp/convert-powerpoint-to-html/)、[SVG](/slides/ja/cpp/render-a-slide-as-an-svg-image/)、および [images](/slides/ja/cpp/convert-powerpoint-to-png/) などにエクスポートできます。

### テンプレート (POTX/POTM) から開始し、通常の PPTX として保存できますか？

はい。テンプレートを読み込み、目的の形式で保存できます。POTX/POTM/PPTM などの形式は[サポートされています](/slides/ja/cpp/supported-file-formats/)。

### プレゼンテーション作成時にスライドサイズ/アスペクト比を制御するには？

[スライドサイズ](/slides/ja/cpp/slide-size/) を設定し（4:3 や 16:9 などのプリセットやカスタム寸法を含む）、コンテンツのスケーリング方法を選択します。

### サイズや座標はどの単位で測定されますか？

ポイントで測定されます。1 インチは 72 ユニットです。

### 非常に大きなプレゼンテーション（多数のメディアファイルを含む）でメモリ使用量を削減するには？

[BLOB 管理戦略](/slides/ja/cpp/manage-blob/) を使用し、一時ファイルを活用してメモリ内の保存を制限し、純粋にメモリ上のストリームよりもファイルベースのワークフローを優先します。

### プレゼンテーションを並列で作成/保存できますか？

同じ [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) インスタンスを[複数のスレッド](/slides/ja/cpp/multithreading/)から操作することはできません。各スレッドまたはプロセスごとに別々の独立したインスタンスを実行してください。

### 試用版の透かしと制限を削除するには？

プロセスごとに一度だけ[ライセンスを適用](/slides/ja/cpp/licensing/)してください。ライセンス XML は変更せず、その設定は複数スレッドが関与する場合は同期させる必要があります。

### 作成した PPTX にデジタル署名できますか？

はい。プレゼンテーションでは[デジタル署名](/slides/ja/cpp/digital-signature-in-powerpoint/)（追加と検証）がサポートされています。

### 作成したプレゼンテーションでマクロ (VBA) はサポートされていますか？

はい。[VBA プロジェクトの作成/編集](/slides/ja/cpp/presentation-via-vba/) が可能で、PPTM/PPSM などのマクロ有効ファイルとして保存できます。