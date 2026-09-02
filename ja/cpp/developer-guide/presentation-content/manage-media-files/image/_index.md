---
title: C++ を使用したプレゼンテーションの画像管理の最適化
linktitle: 画像の管理
type: docs
weight: 10
url: /ja/cpp/image/
keywords:
- 画像の追加
- ピクチャの追加
- 画像の置換
- 画像コレクション
- 画像フレーム
- リンク画像
- 背景
- PNG の追加
- JPG の追加
- SVG の追加
- SVG からシェイプへ
- 外部 SVG リソース
- PowerPoint
- OpenDocument
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を使用して、PowerPoint および OpenDocument プレゼンテーションでラスター画像と SVG 画像を追加、再利用、リンク、置換、管理する方法を学びます。"
---
## **はじめに**

Aspose.Slides for C++ は画像を扱う複数の方法を提供し、それぞれが異なる目的に役立ちます。画像をプレゼンテーションに保存したり、画像フレームで表示したり、スライドの背景として使用したり、外部画像へリンクしたり、共有画像リソースを置き換えたり、SVG コンテンツを編集可能なシェイプに変換したりできます。

この記事では画像リソースとそれがプレゼンテーション全体でどのように使用されるかに焦点を当てます。個々の画像フレームに適用されるトリミング、透過、効果、伸縮、その他の書式設定については、[画像フレーム](/slides/ja/cpp/picture-frame/)をご覧ください。

## **画像モデルの理解**

以下の API 概念は密接に関連していますが、互換性はありません。

- [プレゼンテーション画像コレクション](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iimagecollection/) は、プレゼンテーションで使用される画像リソースを保存します。画像データを追加し、[IPPImage](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ippimage/) リソースを取得するには、[IImageCollection::AddImage](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iimagecollection/addimage/) を使用します。
- [画像フレーム](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ipictureframe/) は、スライド、レイアウト、またはマスター上に画像を表示するシェイプです。スライド上に画像リソースを配置するには、[IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ishapecollection/addpictureframe/) を使用します。
- スライドの背景は、シェイプではなくスライドの塗りつぶしの一部として画像を使用します。そのため、画像フレームのようには動作しません。
- [IPPImage::ReplaceImage](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ippimage/replaceimage/) は画像リソースを置き換えます。そのリソースを複数のプレゼンテーション要素が使用している場合、すべてが置き換え後のものを使用します。
- SVG をシェイプに変換すると、編集可能なスライドシェイプが作成されます。変換後は、コンテンツは単一の画像リソースとして管理されなくなります。

したがって、典型的なワークフローは次のとおりです。画像データを画像コレクションに追加し、[IPPImage](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ippimage/) を取得し、そのリソースを 1 つ以上の画像フレームまたは塗りつぶしで使用します。

## **埋め込み画像の追加**

ローカル画像を挿入するには、ファイルを読み取り、そのデータを画像コレクションに追加し、返された [IPPImage](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ippimage/) リソースを使用する画像フレームを作成します。

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();

auto imageData = File::ReadAllBytes(u"photo.png");
auto image = presentation->get_Images()->AddImage(imageData);

auto slide = presentation->get_Slide(0);
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20.0f, 20.0f, 320.0f, 180.0f, image);

presentation->Save(u"presentation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

この方法で追加された画像はプレゼンテーションに埋め込まれるため、結果として生成されるファイルは元の画像ファイルが利用可能である必要がありません。

### **Web から画像を追加**

画像が HTTP または HTTPS 経由で利用可能な場合、そのバイト列をダウンロードし、プレゼンテーション画像コレクションに追加し、ローカル画像と同様に返された画像リソースを使用します。

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <net/web_client.h>
#include <system/uri.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Net;

auto imageUri = MakeObject<Uri>(u"https://example.com/image.png");
auto webClient = MakeObject<WebClient>();
auto imageData = webClient->DownloadData(imageUri);

auto presentation = MakeObject<Presentation>();

auto image = presentation->get_Images()->AddImage(imageData);
auto slide = presentation->get_Slide(0);
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20.0f, 20.0f, 320.0f, 180.0f, image);

presentation->Save(u"presentation-from-web.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

ソースが信頼できない場合は、リモート URL、レスポンスサイズ、コンテンツタイプを検証してください。すでに別の HTTP クライアントを使用しているアプリケーションでは、そのクライアントで画像をダウンロードし、得られたバイト列またはストリームを [IImageCollection::AddImage](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iimagecollection/addimage/) に渡すことができます。

## **スライド間で画像を再利用**

同じ画像が複数回必要な場合は、プレゼンテーションに一度だけ追加し、追加の画像フレームを作成するときに返された [IPPImage](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ippimage/) を再利用します。これにより同一のソースデータを繰り返しロードすることが防がれ、共有画像リソースとその使用箇所の関係が明示的になります。

多数のスライドで自動的に表示したいロゴなどのグラフィックは、各スライドに同等のシェイプを追加する代わりに、[スライドマスター](/slides/ja/cpp/slide-master/) またはレイアウト上に画像フレームを配置することを検討してください。

## **画像をスライドの背景として使用**

背景画像はスライドの塗りつぶしに割り当てられ、画像フレームとして追加されません。画像がスライド全体の背景を覆い、通常のスライドオブジェクトとして操作されない場合に便利です。

```cpp
#include <DOM/BackgroundType.h>
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IFillFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto imageData = File::ReadAllBytes(u"background.jpg");
auto image = presentation->get_Images()->AddImage(imageData);

slide->get_Background()->set_Type(BackgroundType::OwnBackground);
slide->get_Background()->get_FillFormat()->set_FillType(FillType::Picture);
slide->get_Background()->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);
slide->get_Background()->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(image);

presentation->Save(u"background-image.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

マスターやレイアウトの背景を含む追加の背景オプションについては、[Presentation Background](/slides/ja/cpp/presentation-background/) を参照してください。

## **埋め込み画像とリンク画像**

埋め込み画像とリンク画像は、可搬性とファイルサイズのトレードオフが異なります。

- **埋め込み画像:** 画像データがプレゼンテーション内部に保存されます。プレゼンテーションは単体で完結しますが、ファイルサイズに画像データが含まれます。
- **リンク画像:** プレゼンテーションは外部画像へのパスまたは URL を保持します。プレゼンテーションサイズを削減できますが、開くまたはレンダリングする際に外部リソースが利用可能である必要があります。

リンク画像は、[ISlidesPicture::set_LinkPathLong](https://reference.aspose.com/slides/ja/cpp/aspose.slides/islidespicture/set_linkpathlong/) を使用して外部パスまたは URL を割り当てることで作成でき、画像データを埋め込む必要はありません。

```cpp
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20.0f, 20.0f, 320.0f, 180.0f, nullptr);
pictureFrame->get_PictureFormat()->get_Picture()->set_LinkPathLong(u"https://example.com/image.png");

presentation->Save(u"linked-image.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

外部リソースに確実にアクセスできる環境でのみリンク画像を使用してください。オフラインで動作させる必要があるプレゼンテーションやシステム間で移動する場合は、埋め込み画像の方が安全です。

## **SVG 画像の操作**

SVG はベクタ形式であるため、アイコン、図表、その他ラスタ画像と比べて詳細を失わずに拡大縮小できるグラフィックに適しています。Aspose.Slides は SVG を画像リソースとして、または編集可能なスライドシェイプのソースとしてサポートします。

### **SVG を画像として追加**

[SvgImage](https://reference.aspose.com/slides/ja/cpp/aspose.slides/svgimage/) を作成し、画像コレクションに追加し、得られた画像リソースを画像フレームに配置します。

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SvgImage.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto svgContent = File::ReadAllText(u"icon.svg");
auto svgImage = MakeObject<SvgImage>(svgContent);

auto presentation = MakeObject<Presentation>();

auto image = presentation->get_Images()->AddImage(svgImage);
auto slide = presentation->get_Slide(0);
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20.0f, 20.0f, 200.0f, 200.0f, image);

presentation->Save(u"svg-image.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **外部リソースを持つ SVG ファイル**

SVG は外部画像、スタイルシート、フォントを参照できる場合があります。このようなケースでは、[SvgImage](https://reference.aspose.com/slides/ja/cpp/aspose.slides/svgimage/) が [IExternalResourceResolver](https://reference.aspose.com/slides/ja/cpp/aspose.slides.import/iexternalresourceresolver/) とベース URI を受け取るコンストラクタを提供します。リゾルバは相対 URI を許可された絶対 URI にマッピングし、要求されたリソースのストリームを返すことができます。

リゾルバは SVG 処理中に外部リソースへのアクセスを可能にしますが、SVG を自己完結型ドキュメントに書き換えるわけではありません。SVG を可搬性のまま保ちたい場合は、リンク画像に `data:` URI を使用するなどして必要なリソースを SVG 自体に埋め込んでください。

信頼できないソースから SVG ファイルを取得する場合、リゾルバがアクセスできるスキーム、ファイル位置、ホストを制限してください。ネットワークリゾルバにはタイムアウト、レスポンスサイズ制限、コンテンツ検証を適用すべきです。

### **SVG を編集可能なシェイプに変換**

Aspose.Slides は SVG を編集可能なスライドシェイプのグループに変換でき、PowerPoint の対応コマンドと同様です。

![PowerPoint ポップアップメニュー](img_01_01.png)

変換を実行するには、[IShapeCollection::AddGroupShape](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ishapecollection/addgroupshape/) のオーバーロードで [ISvgImage](https://reference.aspose.com/slides/ja/cpp/aspose.slides/isvgimage/) を受け取るものを使用します。

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SvgImage.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto svgContent = File::ReadAllText(u"diagram.svg");
auto svgImage = MakeObject<SvgImage>(svgContent);

auto presentation = MakeObject<Presentation>();

auto slideSize = presentation->get_SlideSize()->get_Size();
auto slide = presentation->get_Slide(0);
slide->get_Shapes()->AddGroupShape(svgImage, 0.0f, 0.0f, slideSize.get_Width(), slideSize.get_Height());

presentation->Save(u"editable-svg-shapes.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

個々のベクタ要素を PowerPoint シェイプとして編集する必要がある場合に SVG からシェイプへの変換を使用してください。表示のみが目的であれば、画像として保持した方がシンプルで多数の個別シェイプを作成する手間が省けます。

## **既存の画像リソースを置き換える**

既存の画像リソースを置き換える場合は、[IPPImage::ReplaceImage](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ippimage/replaceimage/) を使用します。ロゴなどの共有グラフィックを置き換える際に特に便利です。

```cpp
#include <DOM/IPPImage.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"input.pptx");

auto imageToReplace = presentation->get_Image(0);
auto imageData = File::ReadAllBytes(u"new-logo.png");
imageToReplace->ReplaceImage(imageData);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

同じ画像リソースを複数の画像フレーム、背景、マスター、レイアウトが使用している場合、そのリソースを置き換えるとすべての使用箇所が更新されます。1 つの画像フレームだけを変更したい場合は、共有リソースを置き換えるのではなく、そのフレームに別の画像を割り当ててください。

[IPPImage::ReplaceImage](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ippimage/replaceimage/) には、[IImage](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iimage/) または別の [IPPImage](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ippimage/) を受け取るオーバーロードも用意されています。

## **実践的な画像管理ガイドライン**

### **プレゼンテーションサイズの管理**

大きなラスタ画像はプレゼンテーションを不必要に肥大化させます。表示サイズに見合った寸法のソース画像を使用し、可能な限り共有画像リソースを再利用し、同一の高解像度画像を繰り返し埋め込むことを避けてください。

既に画像フレームに配置されたラスタ画像については、[IPictureFillFormat::CompressImage](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ipicturefillformat/compressimage/) を使用して、選択された解像度とトリミング設定に基づき画像データを圧縮できます。これは画像フレームの処理であり画像コレクションの管理ではないため、関連する書式操作は [画像フレーム](/slides/ja/cpp/picture-frame/) を参照してください。

### **埋め込みとリンクコンテンツの選択**

埋め込みはすべての画像データがファイルに同梱されるため、プレゼンテーションの可搬性が高まります。リンクはファイルサイズを削減できますが、外部依存が生じます。外部依存が許容でき、かつ安定している場合にのみリンクを使用してください。

### **共有ブランドの再利用**

ロゴ、透かし、装飾グラフィックなど繰り返し使用する要素は、1 つの画像リソースを作成して再利用してください。そのグラフィックがスライドコンテンツではなくデザインに属する場合は、マスターまたはレイアウトに配置して該当スライドに継承させます。

### **SVG リソースをポータブルに保つ**

自己完結型 SVG は、外部ファイルやネットワークリソースに依存する SVG よりも移動やレンダリングが容易です。可能な限りインポート前に必要なリソースを埋め込み、個々のベクタ要素を編集する必要があるときだけ SVG をシェイプに変換してください。

### **Aspose.Slides の画像 API を使用**

C++ の画像ワークフローでは、画像オブジェクトが必要なときは Aspose.Slides の [IImage](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iimage/) および [Images](https://reference.aspose.com/slides/ja/cpp/aspose.slides/images/) API を使用し、プレゼンテーションリソースとして画像データを登録する必要があるときは [IImageCollection::AddImage](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iimagecollection/addimage/) を使用してください。コレクションのオーバーロードはバイト配列やストリームもサポートしており、画像データがファイル、ネットワーククライアント、データベース、その他のライブラリから取得される場合に便利です。

スプレッドシートや別製品から EMF コンテンツを生成するのは別の統合ワークフローであり、本記事の範囲外です。既存の WMF または EMF ファイルをプレゼンテーションに挿入するだけであれば、画像管理ワークフローに余計な製品依存を追加せずに、適切な [IImageCollection::AddImage](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iimagecollection/addimage/) オーバーロードにデータを渡してください。

## **FAQ**

**画像コレクションと画像フレームの違いは何ですか？**

画像コレクションは再利用可能な画像リソースを保存します。画像フレームはそれらのリソースの 1 つを表示するスライドシェイプで、トリミングや効果といった画像固有の書式設定を提供します。

**ロゴをすべての場所で置き換える最良の方法は何ですか？**

ロゴが 1 つの画像リソースとして共有されている場合は、[IPPImage::ReplaceImage](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ippimage/replaceimage/) でそのリソースを置き換えてください。プレゼンテーション全体のブランディングの場合は、マスターまたはレイアウトにロゴを配置すると、スライドの重複コンテンツを減らすこともできます。

**リンク画像が別のコンピュータで消えるのはなぜですか？**

リンク画像は外部ファイルまたは URL に依存しています。別のコンピュータからそのリソースにアクセスできない場合、リンク画像は利用できなくなります。プレゼンテーションを単体で完結させる必要がある場合は、画像を埋め込んでください。

**挿入した SVG を PowerPoint シェイプとして編集できますか？**

はい。SVG を [IShapeCollection::AddGroupShape](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ishapecollection/addgroupshape/) で変換すると、結果のグループは 1 つの SVG 画像ではなく、編集可能なスライドシェイプを含むようになります。

**多数の画像を含むプレゼンテーションのサイズを小さく保つにはどうすればよいですか？**

共有画像リソースを再利用し、不要に大きなラスタソースを避け、適切な場合はラスタ画像を圧縮し、繰り返し使用するブランドはマスターやレイアウトに配置し、外部依存が許容できる場合にのみリンク画像を使用してください。