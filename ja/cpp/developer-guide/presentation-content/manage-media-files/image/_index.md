---
title: C++ を使用したプレゼンテーションの画像管理の最適化
linktitle: 画像を管理する
type: docs
weight: 10
url: /ja/cpp/image/
keywords:
- 画像を追加
- ピクチャーを追加
- ビットマップを追加
- 画像を置き換える
- ピクチャーを置き換える
- Web から
- 背景
- PNG を追加
- JPG を追加
- SVG を追加
- EMF を追加
- WMF を追加
- TIFF を追加
- PowerPoint
- OpenDocument
- プレゼンテーション
- EMF
- SVG
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を使用して PowerPoint および OpenDocument の画像管理を効率化し、パフォーマンスを最適化し、ワークフローを自動化します。"
---

## **プレゼンテーションスライドの画像**

画像はプレゼンテーションをより魅力的で面白くします。Microsoft PowerPoint では、ファイル、インターネット、またはその他の場所から画像をスライドに挿入できます。同様に、Aspose.Slides ではさまざまな手順でプレゼンテーションのスライドに画像を追加できます。

{{% alert title="Tip" color="primary" %}} 
Aspose は無料コンバータ―[JPEG to PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) と [PNG to PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)―を提供しており、画像から迅速にプレゼンテーションを作成できます。 
{{% /alert %}} 

{{% alert title="Info" color="info" %}}
フレーム オブジェクトとして画像を追加したい場合（サイズ変更や効果の適用など、標準の書式オプションを使用したい場合）は、[Picture Frame](/slides/ja/cpp/picture-frame/) を参照してください。 
{{% /alert %}} 

{{% alert title="Note" color="warning" %}}
画像と PowerPoint プレゼンテーションの入出力操作を操作して、画像を別の形式に変換できます。次のページをご覧ください: 画像を JPG に変換[image to JPG](https://products.aspose.com/slides/cpp/conversion/image-to-jpg/); JPG を画像に変換[jpg to image](https://products.aspose.com/slides/cpp/conversion/jpg-to-image/); JPG を PNG に変換[jpg to png](https://products.aspose.com/slides/cpp/conversion/jpg-to-png/), PNG を JPG に変換[png to jpg](https://products.aspose.com/slides/cpp/conversion/png-to-jpg/); PNG を SVG に変換[png to svg](https://products.aspose.com/slides/cpp/conversion/png-to-svg/), SVG を PNG に変換[svg to png](https://products.aspose.com/slides/cpp/conversion/svg-to-png/)。 
{{% /alert %}}

Aspose.Slides は JPEG、PNG、GIF などの一般的な形式の画像操作をサポートします。

## **ローカルに保存された画像をスライドに追加する**

コンピューター上の 1 つまたは複数の画像をプレゼンテーションのスライドに追加できます。以下の C++ サンプルコードは、画像をスライドに追加する方法を示しています:
``` cpp
auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);
auto image = pres->get_Images()->AddImage(File::ReadAllBytes(u"image.png"));
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```


## **Web から画像をスライドに追加する**

スライドに追加したい画像がコンピューターにない場合、Web から直接画像を追加できます。

このサンプルコードは、Web から画像を取得して C++ でスライドに追加する方法を示しています:
``` cpp
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
    
auto webClient = System::MakeObject<WebClient>();
auto imageData = webClient->DownloadData(System::MakeObject<Uri>(u"[REPLACE WITH URL]"));

auto image = pres->get_Images()->AddImage(imageData);
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```


## **スライド マスターに画像を追加する**

スライド マスターは、下位のすべてのスライドに関する情報（テーマ、レイアウトなど）を保存および管理する最上位スライドです。したがって、スライド マスターに画像を追加すると、その画像はそのマスター配下のすべてのスライドに表示されます。

この C++ サンプルコードは、スライド マスターに画像を追加する方法を示しています:
``` cpp
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto masterSlide = slide->get_LayoutSlide()->get_MasterSlide();

auto image = pres->get_Images()->AddImage(File::ReadAllBytes(u"image.png"));
masterSlide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```


## **スライドの背景として画像を追加する**

特定のスライドまたは複数のスライドの背景に画像を使用したい場合は、*[Setting Images as Backgrounds for Slides](https://docs.aspose.com/slides/cpp/presentation-background/#setting-images-as-background-for-slides)* を参照してください。

## **プレゼンテーションに SVG を追加する**
[AddPictureFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape_collection#ab55ae8c24dd32665637725a26ca1c1a9) メソッド（[IShapeCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape_collection) インターフェイスの一部）を使用して、任意の画像をプレゼンテーションに追加または挿入できます。

SVG 画像に基づく画像オブジェクトを作成するには、次の手順で行います。

1. SvgImage オブジェクトを作成して ImageShapeCollection に挿入する  
2. ISvgImage から PPImage オブジェクトを作成する  
3. IPPImage インターフェイスを使用して PictureFrame オブジェクトを作成する  

このサンプルコードは、上記手順を実装して SVG 画像をプレゼンテーションに追加する方法を示しています:
``` cpp 
// ドキュメントディレクトリへのパス
System::String dataDir = u"D:\\Documents\\";

// ソース SVG ファイル名
System::String svgFileName = dataDir + u"sample.svg";

// 出力プレゼンテーションファイル名
System::String outPptxPath = dataDir + u"presentation.pptx";

// 新しいプレゼンテーションを作成
auto p = System::MakeObject<Presentation>();

// SVG ファイルの内容を読み取る
System::String svgContent = File::ReadAllText(svgFileName);

// SvgImage オブジェクトを作成
System::SharedPtr<ISvgImage> svgImage = System::MakeObject<SvgImage>(svgContent);

// PPImage オブジェクトを作成
System::SharedPtr<IPPImage> ppImage = p->get_Images()->AddImage(svgImage);

// 新しい PictureFrame を作成 
p->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 200.0f, 100.0f, static_cast<float>(ppImage->get_Width()), static_cast<float>(ppImage->get_Height()), ppImage);

// プレゼンテーションを PPTX 形式で保存
p->Save(outPptxPath, SaveFormat::Pptx);
```


## **SVG を図形セットに変換する**
Aspose.Slides の SVG から図形セットへの変換は、PowerPoint の SVG 画像操作機能と同様です:

![PowerPoint Popup Menu](img_01_01.png)

この機能は、[IShapeCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape_collection) インターフェイスの [AddGroupShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape_collection#a07def8851fe87a8f73a1621d2375d13b) メソッドのオーバーロードの一つによって提供され、最初の引数に [ISvgImage](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_svg_image) オブジェクトを受け取ります。

このサンプルコードは、上記メソッドを使用して SVG ファイルを図形セットに変換する方法を示しています:
``` cpp 
// ドキュメントディレクトリへのパス
System::String dataDir = u"D:\\Documents\\";

// ソース SVG ファイル名
System::String svgFileName = dataDir + u"sample.svg";

// 出力プレゼンテーションファイル名
System::String outPptxPath = dataDir + u"presentation.pptx";

// 新しいプレゼンテーションを作成
System::SharedPtr<IPresentation> presentation = System::MakeObject<Presentation>();

// SVG ファイルの内容を読み取る
System::String svgContent = File::ReadAllText(svgFileName);

// SvgImage オブジェクトを作成
System::SharedPtr<ISvgImage> svgImage = System::MakeObject<SvgImage>(svgContent);

// スライドサイズを取得
System::Drawing::SizeF slideSize = presentation->get_SlideSize()->get_Size();

// SVG 画像をスライドサイズに合わせてグループ図形に変換
presentation->get_Slides()->idx_get(0)->get_Shapes()->AddGroupShape(svgImage, 0.f, 0.f, slideSize.get_Width(), slideSize.get_Height());

// プレゼンテーションを PPTX 形式で保存
presentation->Save(outPptxPath, SaveFormat::Pptx);
```


## **画像を EMF としてスライドに追加する**
Aspose.Slides for C++ は、Excel シートから EMF 画像を生成し、Aspose.Cells と連携してスライドに EMF として画像を追加できます。

このサンプルコードは、記載されたタスクを実行する方法を示しています:
``` cpp 
System::String dataDir = u"D:\\Documents\\";

StringPtr cellsXls = new String(dataDir.ToWCS().c_str());
cellsXls->Append(L"chart.xls");
intrusive_ptr<Aspose::Cells::IWorkbook> book = Aspose::Cells::Factory::CreateIWorkbook(cellsXls);

intrusive_ptr<Aspose::Cells::IWorksheet> sheet = book->GetIWorksheets()->GetObjectByIndex(0);
intrusive_ptr<Aspose::Cells::Rendering::IImageOrPrintOptions> options = Aspose::Cells::Factory::CreateIImageOrPrintOptions();
options->SetHorizontalResolution(200);
options->SetVerticalResolution(200);
options->SetImageFormat(Aspose::Cells::Systems::Drawing::Imaging::ImageFormat::GetEmf());

// Save the workbook to stream
intrusive_ptr<Aspose::Cells::Rendering::ISheetRender> sr = Aspose::Cells::Factory::CreateISheetRender(sheet, options);

System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

pres->get_Slides()->RemoveAt(0);

System::String EmfSheetName;
for (int32_t j = 0; j < sr->GetPageCount(); j++)
{
    EmfSheetName = dataDir + u"test" + System::String::FromWCS(sheet->GetName()->value()) + u" Page" + (j + 1) + u".out.emf";
    sr->ToImage(j, new String(EmfSheetName.ToWCS().c_str()));

    auto bytes = System::IO::File::ReadAllBytes(EmfSheetName);
    auto emfImage = pres->get_Images()->AddImage(bytes);

    System::SharedPtr<ISlide> slide = pres->get_Slides()->AddEmptySlide(pres->get_LayoutSlides()->GetByType(SlideLayoutType::Blank));
    auto slideSize = pres->get_SlideSize()->get_Size();
    slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 0.0f, 0.0f, slideSize.get_Width(), slideSize.get_Height(), emfImage);
}

pres->Save(dataDir + u"Saved.pptx", SaveFormat::Pptx);
```


## **画像コレクション内の画像を置き換える**

Aspose.Slides では、プレゼンテーションの画像コレクション（スライド シェイプが使用している画像を含む）に保存されている画像を置き換えることができます。このセクションでは、コレクション内の画像を更新するための複数のアプローチを示します。API は、生のバイト データ、[IImage](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/) インスタンス、またはコレクション内に既に存在する別の画像を使用して画像を置き換えるためのシンプルなメソッドを提供します。

以下の手順に従ってください:

1. [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) クラスを使用して、画像を含むプレゼンテーション ファイルをロードします。  
1. ファイルから新しい画像をバイト配列にロードします。  
1. バイト配列を使用して対象画像を新しい画像に置き換えます。  
1. 2 番目のアプローチでは、画像を [IImage](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/) オブジェクトにロードし、そのオブジェクトで対象画像を置き換えます。  
1. 3 番目のアプローチでは、コレクション内に既に存在する画像で対象画像を置き換えます。  
1. 変更されたプレゼンテーションを PPTX ファイルとして保存します。  
```cpp
// プレゼンテーションファイルを表す Presentation クラスのインスタンスを作成します。
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// 最初の方法。
auto imageData = File::ReadAllBytes(u"image0.jpeg");
auto oldImage = presentation->get_Image(0);
oldImage->ReplaceImage(imageData);

// 二番目の方法。
auto newImage = Images::FromFile(u"image1.png");
oldImage = presentation->get_Image(1);
oldImage->ReplaceImage(newImage);
newImage->Dispose();

// 三番目の方法。
oldImage = presentation->get_Image(2);
oldImage->ReplaceImage(presentation->get_Image(3));

// プレゼンテーションをファイルに保存します。
presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


{{% alert title="Info" color="info" %}}
Aspose の無料 [Text to GIF](https://products.aspose.app/slides/text-to-gif) コンバータを使用すると、テキストを簡単にアニメーション化したり、テキストから GIF を作成したりできます。 
{{% /alert %}}

## **FAQ**

**画像を挿入した後、元の解像度は維持されますか？**

はい。元のピクセルは保持されますが、最終的な見た目はスライド上の [picture](/slides/ja/cpp/picture-frame/) のスケーリング方法や保存時に適用される圧縮に依存します。

**多数のスライドにわたって同じロゴを一括で置き換える最適な方法は？**

マスタースライドまたはレイアウトにロゴを配置し、プレゼンテーションの画像コレクションで置き換えると、該当リソースを使用しているすべての要素に自動的に反映されます。

**挿入した SVG を編集可能な図形に変換できますか？**

はい。SVG を図形のグループに変換でき、その後個々のパーツは標準の図形プロパティで編集可能になります。

**複数スライドの背景に同じ画像を一括で設定するには？**

マスタースライドまたは該当レイアウトで画像を背景として割り当てます（[Assign the image as the background](/slides/ja/cpp/presentation-background/)）。そのマスター/レイアウトを使用しているすべてのスライドが背景を継承します。

**多数の画像でプレゼンテーションのサイズが膨張するのを防ぐには？**

画像の重複を避けて単一リソースを再利用し、適切な解像度を選択し、保存時に圧縮を適用し、繰り返し使用するグラフィックは可能な限りマスターに配置してください。