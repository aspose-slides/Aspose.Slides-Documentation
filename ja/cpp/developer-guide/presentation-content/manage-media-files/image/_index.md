---
title: 画像
type: docs
weight: 10
url: /cpp/image/
---


## **プレゼンテーションのスライドの画像**

画像は、プレゼンテーションをより魅力的で面白くします。Microsoft PowerPointでは、ファイル、インターネット、その他の場所からスライドに画像を挿入できます。同様に、Aspose.Slidesを使用すると、さまざまな手順でプレゼンテーションのスライドに画像を追加できます。

{{% alert title="ヒント" color="primary" %}} 

Asposeは、画像からすぐにプレゼンテーションを作成できる無料のコンバーター—[JPEGからPowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt)および[PNGからPowerPoint](https://products.aspose.app/slides/import/png-to-ppt)—を提供しています。

{{% /alert %}} 

{{% alert title="情報" color="info" %}}

フレームオブジェクトとして画像を追加したい場合—特に、サイズ変更、効果の追加などの標準フォーマットオプションを使用する予定がある場合—は、[ピクチャーフレーム](/slides/cpp/picture-frame/)を参照してください。

{{% /alert %}} 

{{% alert title="注" color="warning" %}}

画像とPowerPointプレゼンテーションを含む入出力操作を操作して、画像を別の形式に変換できます。これらのページを参照してください：[画像をJPGに変換](https://products.aspose.com/slides/cpp/conversion/image-to-jpg/); [JPGを画像に変換](https://products.aspose.com/slides/cpp/conversion/jpg-to-image/); [JPGをPNGに変換](https://products.aspose.com/slides/cpp/conversion/jpg-to-png/)、[PNGをJPGに変換](https://products.aspose.com/slides/cpp/conversion/png-to-jpg/); [PNGをSVGに変換](https://products.aspose.com/slides/cpp/conversion/png-to-svg/)、[SVGをPNGに変換](https://products.aspose.com/slides/cpp/conversion/svg-to-png/)。

{{% /alert %}}

Aspose.Slidesは、JPEG、PNG、GIFなどの人気のある形式での画像操作をサポートしています。

## **ローカルに保存された画像をスライドに追加する**

コンピュータ上の1枚または複数の画像をプレゼンテーションのスライドに追加できます。以下のC++のサンプルコードは、スライドに画像を追加する方法を示しています：

``` cpp
auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);
auto image = pres->get_Images()->AddImage(File::ReadAllBytes(u"image.png"));
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```



## **ウェブからスライドに画像を追加する**

スライドに追加したい画像がコンピュータ上にない場合、ウェブから直接画像を追加できます。

以下のサンプルコードは、ウェブからスライドに画像を追加する方法を示しています：

``` cpp
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
    
auto webClient = System::MakeObject<WebClient>();
auto imageData = webClient->DownloadData(System::MakeObject<Uri>(u"[REPLACE WITH URL]"));

auto image = pres->get_Images()->AddImage(imageData);
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **スライドマスターに画像を追加する**

スライドマスターは、すべてのスライドに関する情報（テーマ、レイアウトなど）を格納および制御する最上位のスライドです。そのため、スライドマスターに画像を追加すると、その画像はそのスライドマスターの下にあるすべてのスライドに表示されます。

以下のC++サンプルコードは、スライドマスターに画像を追加する方法を示しています：

``` cpp
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto masterSlide = slide->get_LayoutSlide()->get_MasterSlide();

auto image = pres->get_Images()->AddImage(File::ReadAllBytes(u"image.png"));
masterSlide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **スライドの背景として画像を追加する**

特定のスライドまたは複数のスライドの背景として画像を使用することを決定することができます。その場合、* [スライドの背景として画像を設定する](https://docs.aspose.com/slides/cpp/presentation-background/#setting-images-as-background-for-slides)*を参照する必要があります。

## **プレゼンテーションにSVGを挿入/追加する**
[AddPictureFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape_collection#ab55ae8c24dd32665637725a26ca1c1a9)メソッドを使用して、[IShapeCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape_collection)インターフェイスに属する任意の画像をプレゼンテーションに追加または挿入できます。

SVG画像に基づいて画像オブジェクトを作成するには、次のようにします：

1. SvgImageオブジェクトを作成してImageShapeCollectionに挿入します
2. ISvgImageからPPImageオブジェクトを作成します
3. IPPImageインターフェイスを使用してPictureFrameオブジェクトを作成します

このサンプルコードは、上記の手順を実装してSVG画像をプレゼンテーションに追加する方法を示しています：
``` cpp 
// ドキュメントディレクトリへのパス
System::String dataDir = u"D:\\Documents\\";

// ソースSVGファイル名
System::String svgFileName = dataDir + u"sample.svg";

// 出力プレゼンテーションファイル名
System::String outPptxPath = dataDir + u"presentation.pptx";

// 新しいプレゼンテーションを作成
auto p = System::MakeObject<Presentation>();

// SVGファイルの内容を読み取る
System::String svgContent = File::ReadAllText(svgFileName);

// SvgImageオブジェクトを作成
System::SharedPtr<ISvgImage> svgImage = System::MakeObject<SvgImage>(svgContent);

// PPImageオブジェクトを作成
System::SharedPtr<IPPImage> ppImage = p->get_Images()->AddImage(svgImage);

// 新しいPictureFrameを作成 
p->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 200.0f, 100.0f, static_cast<float>(ppImage->get_Width()), static_cast<float>(ppImage->get_Height()), ppImage);

// プレゼンテーションをPPTX形式で保存
p->Save(outPptxPath, SaveFormat::Pptx);
```

## **SVGを一連のシェイプに変換する**
Aspose.SlidesのSVGを一連のシェイプに変換する機能は、SVG画像を操作するために使用されるPowerPointの機能に似ています：


![PowerPointポップアップメニュー](img_01_01.png)

この機能は、最初の引数として[ISvgImage](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_svg_image)オブジェクトを受け取る[IShapeCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape_collection)インターフェイスの[AddGroupShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape_collection#a07def8851fe87a8f73a1621d2375d13b)メソッドのオーバーロードの1つによって提供されます。

このサンプルコードは、SVGファイルを一連のシェイプに変換するために記述されたメソッドを使用する方法を示しています：

``` cpp 
// ドキュメントディレクトリへのパス
System::String dataDir = u"D:\\Documents\\";

// ソースSVGファイル名
System::String svgFileName = dataDir + u"sample.svg";

// 出力プレゼンテーションファイル名
System::String outPptxPath = dataDir + u"presentation.pptx";

// 新しいプレゼンテーションを作成
System::SharedPtr<IPresentation> presentation = System::MakeObject<Presentation>();

// SVGファイルの内容を読み取る
System::String svgContent = File::ReadAllText(svgFileName);

// SvgImageオブジェクトを作成
System::SharedPtr<ISvgImage> svgImage = System::MakeObject<SvgImage>(svgContent);

// スライドサイズを取得
System::Drawing::SizeF slideSize = presentation->get_SlideSize()->get_Size();

// SVG画像をスライドサイズにスケーリングしてシェイプのグループに変換
presentation->get_Slides()->idx_get(0)->get_Shapes()->AddGroupShape(svgImage, 0.f, 0.f, slideSize.get_Width(), slideSize.get_Height());

// プレゼンテーションをPPTX形式で保存
presentation->Save(outPptxPath, SaveFormat::Pptx);
```

## **スライドにEMFとして画像を追加する**
Aspose.Slides for C++を使用すると、ExcelシートからEMF画像を生成し、Aspose.CellsでスライドにEMFとして画像を追加できます。

以下のサンプルコードは、説明されたタスクを実行する方法を示しています：

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

// ワークブックをストリームに保存
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

{{% alert title="情報" color="info" %}}

Asposeの無料[テキストからGIF](https://products.aspose.app/slides/text-to-gif)コンバーターを使用すると、テキストを簡単にアニメーション化したり、テキストからGIFを作成したりできます。

{{% /alert %}}