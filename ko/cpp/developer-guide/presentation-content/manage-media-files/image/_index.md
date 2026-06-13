---
title: C++를 사용해 프레젠테이션 이미지 관리 최적화
linktitle: 이미지 관리
type: docs
weight: 10
url: /ko/cpp/image/
keywords:
- 이미지 추가
- 그림 추가
- 비트맵 추가
- 이미지 교체
- 그림 교체
- 웹에서
- 배경
- PNG 추가
- JPG 추가
- SVG 추가
- EMF 추가
- WMF 추가
- TIFF 추가
- PowerPoint
- OpenDocument
- 프레젠테이션
- EMF
- SVG
- C++
- Aspose.Slides
description: "Aspose.Slides for C++를 사용하여 PowerPoint와 OpenDocument에서 이미지 관리를 간소화하고, 성능을 최적화하며 워크플로를 자동화합니다."
---
## **소개**

이미지는 프레젠테이션을 더욱 매력적이고 흥미롭게 만듭니다. Microsoft PowerPoint에서는 파일, 인터넷 또는 기타 위치에서 사진을 슬라이드에 삽입할 수 있습니다. 마찬가지로 Aspose.Slides를 사용하면 다양한 방법으로 프레젠테이션 슬라이드에 이미지를 추가할 수 있습니다.

{{% alert title="팁" color="primary" %}} 

Aspose는 무료 변환기—[JPEG를 PowerPoint로](/slides/ko/cpp/picture-frame/)와 [PNG를 PowerPoint로](/slides/ko/cpp/picture-frame/)—를 제공하여 이미지를 빠르게 프레젠테이션으로 만들 수 있도록 지원합니다. 

{{% /alert %}} 

{{% alert title="정보" color="info" %}}

프레임 개체로 이미지를 추가하고 싶다면—특히 표준 서식 옵션을 사용해 크기를 조정하거나 효과를 추가하려는 경우—[Picture Frame](/slides/ko/cpp/picture-frame/)을 참조하십시오. 

{{% /alert %}} 

{{% alert title="주의" color="warning" %}}

이미지와 PowerPoint 프레젠테이션 간의 입출력 작업을 조작하여 이미지를 다른 형식으로 변환할 수 있습니다. 다음 페이지를 참조하십시오: 변환 [image to JPG]([image to JPG](https://products.aspose.com/slides/ko/cpp/conversion/image-to-jpg/)); 변환 [JPG to image]([JPG to image](https://products.aspose.com/slides/ko/cpp/conversion/jpg-to-image/)); 변환 [JPG to PNG]([JPG to PNG](https://products.aspose.com/slides/ko/cpp/conversion/jpg-to-png/)), 변환 [PNG to JPG]([PNG to JPG](https://products.aspose.com/slides/ko/cpp/conversion/png-to-jpg/)); 변환 [PNG to SVG]([PNG to SVG](https://products.aspose.com/slides/ko/cpp/conversion/png-to-svg/)), 변환 [SVG to PNG]([SVG to PNG](https://products.aspose.com/slides/ko/cpp/conversion/svg-to-png/)). 

{{% /alert %}}

Aspose.Slides는 JPEG, PNG, GIF 등과 같은 일반적인 이미지 형식에 대한 작업을 지원합니다. 

## **로컬에 저장된 이미지 슬라이드에 추가**

컴퓨터에 저장된 하나 이상의 이미지를 프레젠테이션 슬라이드에 추가할 수 있습니다. 다음 C++ 샘플 코드는 이미지를 슬라이드에 추가하는 방법을 보여줍니다:

``` cpp
auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);
auto image = pres->get_Images()->AddImage(File::ReadAllBytes(u"image.png"));
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **웹에서 이미지 슬라이드에 추가**

컴퓨터에 이미지가 없을 경우 웹에서 직접 이미지를 가져와 슬라이드에 추가할 수 있습니다.

다음 C++ 샘플 코드는 웹에서 이미지를 가져와 슬라이드에 추가하는 방법을 보여줍니다:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
    
auto webClient = System::MakeObject<WebClient>();
auto imageData = webClient->DownloadData(System::MakeObject<Uri>(u"[REPLACE WITH URL]"));

auto image = pres->get_Images()->AddImage(imageData);
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **슬라이드 마스터에 이미지 추가**

슬라이드 마스터는 아래에 있는 모든 슬라이드의 테마, 레이아웃 등을 저장하고 제어하는 최상위 슬라이드입니다. 따라서 슬라이드 마스터에 이미지를 추가하면 해당 이미지는 마스터 아래 모든 슬라이드에 표시됩니다.

다음 C++ 샘플 코드는 슬라이드 마스터에 이미지를 추가하는 방법을 보여줍니다:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto masterSlide = slide->get_LayoutSlide()->get_MasterSlide();

auto image = pres->get_Images()->AddImage(File::ReadAllBytes(u"image.png"));
masterSlide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **슬라이드 배경으로 이미지 추가**

특정 슬라이드 또는 여러 슬라이드의 배경으로 그림을 사용하려는 경우 *[슬라이드 배경에 이미지 설정]([Setting Images as Backgrounds for Slides](https://docs.aspose.com/slides/ko/cpp/presentation-background/#setting-images-as-background-for-slides))*을 확인하십시오.

## **프레젠테이션에 SVG 추가**
[AddPictureFrame]([AddPictureFrame](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.i_shape_collection#ab55ae8c24dd32665637725a26ca1c1a9)) 메서드와 [IShapeCollection]([IShapeCollection](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.i_shape_collection)) 인터페이스를 사용하여 프레젠테이션에 任의 이미지를 추가하거나 삽입할 수 있습니다.

SVG 이미지를 기반으로 이미지 객체를 만들려면 다음과 같이 수행합니다:

1. SvgImage 객체를 생성하여 ImageShapeCollection에 삽입합니다.  
2. ISvgImage에서 PPImage 객체를 생성합니다.  
3. IPPImage 인터페이스를 사용하여 PictureFrame 객체를 생성합니다.

다음 샘플 코드는 위 단계들을 구현하여 SVG 이미지를 프레젠테이션에 추가하는 방법을 보여줍니다:
``` cpp 
// 문서 디렉터리 경로
System::String dataDir = u"D:\\Documents\\";

// 소스 SVG 파일 이름
System::String svgFileName = dataDir + u"sample.svg";

// 출력 프레젠테이션 파일 이름
System::String outPptxPath = dataDir + u"presentation.pptx";

// 새 프레젠테이션 생성
auto p = System::MakeObject<Presentation>();

// SVG 파일 내용 읽기
System::String svgContent = File::ReadAllText(svgFileName);

// SvgImage 객체 생성
System::SharedPtr<ISvgImage> svgImage = System::MakeObject<SvgImage>(svgContent);

// PPImage 객체 생성
System::SharedPtr<IPPImage> ppImage = p->get_Images()->AddImage(svgImage);

// 새 PictureFrame 생성 
p->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 200.0f, 100.0f, static_cast<float>(ppImage->get_Width()), static_cast<float>(ppImage->get_Height()), ppImage);

// PPTX 형식으로 프레젠테이션 저장
p->Save(outPptxPath, SaveFormat::Pptx);
```

## **SVG를 도형 집합으로 변환**
Aspose.Slides의 SVG를 도형 집합으로 변환하는 기능은 PowerPoint에서 SVG 이미지를 다룰 때 제공되는 기능과 유사합니다:

![PowerPoint Popup Menu](img_01_01.png)

이 기능은 [IShapeCollection]([IShapeCollection](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.i_shape_collection)) 인터페이스의 [AddGroupShape]([AddGroupShape](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.i_shape_collection#a07def8851fe87a8f73a1621d2375d13b)) 메서드 중 하나의 오버로드를 통해 제공되며, 첫 번째 인수로 [ISvgImage]([ISvgImage](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.i_svg_image)) 객체를 사용합니다.

다음 샘플 코드는 해당 메서드를 사용해 SVG 파일을 도형 집합으로 변환하는 방법을 보여줍니다:

``` cpp 
// 문서 디렉터리 경로
System::String dataDir = u"D:\\Documents\\";

// 소스 SVG 파일 이름
System::String svgFileName = dataDir + u"sample.svg";

// 출력 프레젠테이션 파일 이름
System::String outPptxPath = dataDir + u"presentation.pptx";

// 새 프레젠테이션 생성
System::SharedPtr<IPresentation> presentation = System::MakeObject<Presentation>();

// SVG 파일 내용 읽기
System::String svgContent = File::ReadAllText(svgFileName);

// SvgImage 객체 생성
System::SharedPtr<ISvgImage> svgImage = System::MakeObject<SvgImage>(svgContent);

// 슬라이드 크기 가져오기
System::Drawing::SizeF slideSize = presentation->get_SlideSize()->get_Size();

// SVG 이미지를 슬라이드 크기에 맞게 스케일링하여 도형 그룹으로 변환
presentation->get_Slides()->idx_get(0)->get_Shapes()->AddGroupShape(svgImage, 0.f, 0.f, slideSize.get_Width(), slideSize.get_Height());

// PPTX 형식으로 프레젠테이션 저장
presentation->Save(outPptxPath, SaveFormat::Pptx);
```

## **EMF 이미지로 슬라이드에 이미지 추가**
Aspose.Slides for C++를 사용하면 Excel 시트에서 EMF 이미지를 생성하고 Aspose.Cells와 함께 EMF 이미지를 슬라이드에 추가할 수 있습니다.

다음 샘플 코드는 이 작업을 수행하는 방법을 보여줍니다:

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

// 워크북을 스트림에 저장
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

## **Image Collection의 이미지 교체**

Aspose.Slides를 사용하면 프레젠테이션의 이미지 컬렉션(슬라이드 도형에서 사용하는 이미지 포함)에 저장된 이미지를 교체할 수 있습니다. 이 섹션에서는 컬렉션의 이미지를 업데이트하는 여러 방법을 설명합니다. API는 원시 바이트 데이터, [IImage]([IImage](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iimage/)) 인스턴스, 또는 컬렉션에 이미 존재하는 다른 이미지를 사용해 이미지를 교체하는 간단한 메서드를 제공합니다.

다음 단계에 따라 수행하십시오:

1. [Presentation]([Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/)) 클래스를 사용해 이미지를 포함한 프레젠테이션 파일을 로드합니다.  
2. 파일에서 새 이미지를 바이트 배열로 로드합니다.  
3. 바이트 배열을 사용해 대상 이미지를 새 이미지로 교체합니다.  
4. 두 번째 방법에서는 이미지를 [IImage] 객체에 로드하고 해당 객체로 대상 이미지를 교체합니다.  
5. 세 번째 방법에서는 프레젠테이션 이미지 컬렉션에 이미 존재하는 이미지를 사용해 대상 이미지를 교체합니다.  
6. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

```cpp
// 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// 첫 번째 방법.
auto imageData = File::ReadAllBytes(u"image0.jpeg");
auto oldImage = presentation->get_Image(0);
oldImage->ReplaceImage(imageData);

// 두 번째 방법.
auto newImage = Images::FromFile(u"image1.png");
oldImage = presentation->get_Image(1);
oldImage->ReplaceImage(newImage);
newImage->Dispose();

// 세 번째 방법.
oldImage = presentation->get_Image(2);
oldImage->ReplaceImage(presentation->get_Image(3));

// 프레젠테이션을 파일로 저장합니다.
presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert title="정보" color="info" %}}

Aspose 무료 [Text to GIF]([Text to GIF](https://products.aspose.app/slides/ko/text-to-gif)) 변환기를 사용하면 텍스트를 쉽게 애니메이션화하고, 텍스트에서 GIF를 생성하는 등 다양한 작업을 수행할 수 있습니다. 

{{% /alert %}}

## **FAQ**

**이미지를 삽입한 후 원본 해상도가 유지되나요?**

예. 원본 픽셀은 보존되지만 최종 모습은 슬라이드에서 [picture](/slides/ko/cpp/picture-frame/)가 어떻게 스케일링되는지와 저장 시 적용되는 압축에 따라 달라집니다.

**수십 개 슬라이드에 동일한 로고를 한 번에 교체하려면 가장 좋은 방법은?**

마스터 슬라이드나 레이아웃에 로고를 배치하고 프레젠테이션 이미지 컬렉션에서 교체하면 해당 리소스를 사용하는 모든 요소에 자동으로 적용됩니다.

**삽입된 SVG를 편집 가능한 도형으로 변환할 수 있나요?**

예. SVG를 도형 그룹으로 변환하면 개별 파트를 표준 도형 속성으로 편집할 수 있습니다.

**여러 슬라이드에 한 번에 그림을 배경으로 설정하려면 어떻게 해야 하나요?**

마스터 슬라이드 또는 해당 레이아웃에서 [이미지를 배경으로 지정](/slides/ko/cpp/presentation-background/)하면 해당 마스터/레이아웃을 사용하는 모든 슬라이드가 배경을 상속합니다.

**많은 그림 때문에 프레젠테이션 파일 크기가 급격히 커지는 것을 방지하려면?**

중복된 이미지 대신 단일 이미지 리소스를 재사용하고, 적절한 해상도를 선택하며, 저장 시 압축을 적용하고, 반복 그래픽은 가능한 한 마스터에 두십시오.