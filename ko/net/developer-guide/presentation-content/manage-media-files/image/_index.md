---
title: .NET에서 프레젠테이션 이미지 관리 최적화
linktitle: 이미지 관리
type: docs
weight: 10
url: /ko/net/image/
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
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET를 사용하여 PowerPoint 및 OpenDocument에서 이미지 관리를 간소화하고, 성능을 최적화하며 워크플로를 자동화합니다."
---
## **소개**

이미지는 프레젠테이션을 보다 흥미롭고 매력적으로 만듭니다. Microsoft PowerPoint에서 파일, 인터넷 또는 기타 위치에서 사진을 슬라이드에 삽입할 수 있습니다. 마찬가지로 Aspose.Slides를 사용하면 다양한 방법으로 프레젠테이션 슬라이드에 이미지를 추가할 수 있습니다.

{{% alert title="팁" color="primary" %}} 
Aspose는 무료 변환기—[JPEG를 PowerPoint로](https://products.aspose.app/slides/ko/import/jpg-to-ppt) 및 [PNG를 PowerPoint로](https://products.aspose.app/slides/ko/import/png-to-ppt)—를 제공하여 사용자가 이미지를 빠르게 프레젠테이션으로 만들 수 있게 합니다. 
{{% /alert %}} 

{{% alert title="정보" color="info" %}}
이미지를 프레임 객체로 추가하고 싶다면—특히 크기 변경, 효과 추가 등 표준 서식 옵션을 사용하려는 경우—[그림 프레임](https://docs.aspose.com/slides/ko/net/picture-frame/)을 참고하십시오. 
{{% /alert %}} 

{{% alert title="참고" color="warning" %}}
이미지와 PowerPoint 프레젠테이션에 대한 입출력 작업을 조작하여 이미지를 한 형식에서 다른 형식으로 변환할 수 있습니다. 다음 페이지를 참조하십시오: [이미지를 JPG로 변환](https://products.aspose.com/slides/ko/net/conversion/image-to-jpg/); [JPG를 이미지로 변환](https://products.aspose.com/slides/ko/net/conversion/jpg-to-image/); [JPG를 PNG로 변환](https://products.aspose.com/slides/ko/net/conversion/jpg-to-png/), [PNG를 JPG로 변환](https://products.aspose.com/slides/ko/net/conversion/png-to-jpg/); [PNG를 SVG로 변환](https://products.aspose.com/slides/ko/net/conversion/png-to-svg/), [SVG를 PNG로 변환](https://products.aspose.com/slides/ko/net/conversion/svg-to-png/). 
{{% /alert %}}

Aspose.Slides는 JPEG, PNG, BMP, GIF 등 일반적인 이미지 형식을 지원합니다. 

## **로컬에 저장된 이미지를 슬라이드에 추가**

컴퓨터에 있는 하나 이상의 이미지를 프레젠테이션 슬라이드에 추가할 수 있습니다. 다음 C# 샘플 코드는 슬라이드에 이미지를 추가하는 방법을 보여줍니다:
```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **웹에서 이미지를 슬라이드에 추가**

슬라이드에 추가하려는 이미지가 컴퓨터에 없을 경우, 웹에서 직접 이미지를 추가할 수 있습니다. 
다음 샘플 코드는 C#에서 웹 이미지를 슬라이드에 추가하는 방법을 보여줍니다:
```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];

    byte[] imageData;
    using (WebClient webClient = new WebClient()) 
    {
        imageData = webClient.DownloadData(new Uri("[REPLACE WITH URL]"));
    }
    
    IPPImage image = pres.Images.AddImage(imageData);
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **슬라이드 마스터에 이미지 추가**

슬라이드 마스터는 해당 마스터 아래에 있는 모든 슬라이드의 정보를(테마, 레이아웃 등) 저장하고 제어하는 최상위 슬라이드입니다. 따라서 슬라이드 마스터에 이미지를 추가하면 해당 마스터 아래 모든 슬라이드에 이미지가 표시됩니다. 
다음 C# 샘플 코드는 슬라이드 마스터에 이미지를 추가하는 방법을 보여줍니다:
```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IMasterSlide masterSlide = slide.LayoutSlide.MasterSlide;
    
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    masterSlide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **이미지를 슬라이드 배경으로 추가**

특정 슬라이드 또는 여러 슬라이드의 배경으로 그림을 사용하고자 할 수 있습니다. 이 경우 *[슬라이드 배경으로 이미지 설정](https://docs.aspose.com/slides/ko/net/presentation-background/#setting-images-as-background-for-slides)*을 확인하십시오.

## **프레젠테이션에 SVG 추가**

[IShapeCollection](https://reference.aspose.com/slides/ko/net/aspose.slides/ishapecollection) 인터페이스에 속한 [AddPictureFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/ishapecollection/methods/addpictureframe) 메서드를 사용하여 프레젠테이션에任意의 이미지를 추가하거나 삽입할 수 있습니다.

SVG 이미지를 기반으로 이미지 객체를 생성하려면 다음과 같이 할 수 있습니다:

1. SvgImage 객체를 생성하여 ImageShapeCollection에 삽입합니다.
2. ISvgImage에서 PPImage 객체를 생성합니다.
3. IPPImage 인터페이스를 사용하여 PictureFrame 객체를 생성합니다.

다음 샘플 코드는 위 단계들을 구현하여 SVG 이미지를 프레젠테이션에 추가하는 방법을 보여줍니다:
``` csharp 
// 문서 디렉터리 경로
string dataDir = @"D:\Documents\";

// 원본 SVG 파일 이름
string svgFileName = dataDir + "sample.svg";

// 출력 프레젠테이션 파일 이름
string outPptxPath = dataDir + "presentation.pptx";

// 새 프레젠테이션 생성
using (var p = new Presentation())
{
    // SVG 파일 내용 읽기
    string svgContent = File.ReadAllText(svgFileName);

    // SvgImage 객체 생성
    ISvgImage svgImage = new SvgImage(svgContent);

    // PPImage 객체 생성
    IPPImage ppImage = p.Images.AddImage(svgImage);

    // 새 PictureFrame 생성
    p.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 200, 100, ppImage.Width, ppImage.Height, ppImage);

    // 프레젠테이션을 PPTX 형식으로 저장
    p.Save(outPptxPath, SaveFormat.Pptx);
}
```

## **SVG를 형태 집합으로 변환**

Aspose.Slides의 SVG를 형태 집합으로 변환하는 기능은 SVG 이미지 작업에 사용되는 PowerPoint 기능과 유사합니다:

![PowerPoint Popup Menu](img_01_01.png)

이 기능은 [IShapeCollection](https://reference.aspose.com/slides/ko/net/aspose.slides/ishapecollection) 인터페이스의 [AddGroupShape](https://reference.aspose.com/slides/ko/net/aspose.slides.ishapecollection/addgroupshape/methods/1) 메서드 중 하나의 오버로드에 의해 제공되며, 첫 번째 인수로 [ISvgImage](https://reference.aspose.com/slides/ko/net/aspose.slides/isvgimage) 객체를 받습니다.

다음 샘플 코드는 위에서 설명한 메서드를 사용하여 SVG 파일을 형태 집합으로 변환하는 방법을 보여줍니다:
``` csharp 
// 문서 디렉터리 경로
string dataDir = @"D:\Documents\";

// 원본 SVG 파일 이름
string svgFileName = dataDir + "sample.svg";

// 출력 프레젠테이션 파일 이름
string outPptxPath = dataDir + "presentation.pptx";

// 새 프레젠테이션 생성
using (IPresentation presentation = new Presentation())
{
    // SVG 파일 내용 읽기
    string svgContent = File.ReadAllText(svgFileName);

    // SvgImage 객체 생성
    ISvgImage svgImage = new SvgImage(svgContent);

    // 슬라이드 크기 가져오기
    SizeF slideSize = presentation.SlideSize.Size;

    // SVG 이미지를 슬라이드 크기에 맞게 확대하여 형태 그룹으로 변환
    presentation.Slides[0].Shapes.AddGroupShape(svgImage, 0f, 0f, slideSize.Width, slideSize.Height);

    // 프레젠테이션을 PPTX 형식으로 저장
    presentation.Save(outPptxPath, SaveFormat.Pptx);
}
```

## **이미지를 EMF로 슬라이드에 추가**

Aspose.Slides for .NET를 사용하면 Excel 시트에서 EMF 이미지를 생성하고 Aspose.Cells를 통해 슬라이드에 EMF로 추가할 수 있습니다. 
다음 샘플 코드는 해당 작업을 수행하는 방법을 보여줍니다:
``` csharp 
using (Workbook book = new Workbook(dataDir + "chart.xlsx"))
{
    Worksheet sheet = book.Worksheets[0];
    ImageOrPrintOptions options = new ImageOrPrintOptions();
    options.HorizontalResolution = 200;
    options.VerticalResolution = 200;
    options.ImageFormat = System.Drawing.Imaging.ImageFormat.Emf;

    // 워크북을 스트림에 저장
    SheetRender sr = new SheetRender(sheet, options);
    using (Presentation pres = new Presentation())
    {
        pres.Slides.RemoveAt(0);

        String EmfSheetName = "";
        for (int j = 0; j < sr.PageCount; j++)
        {
            EmfSheetName = dataDir + "test" + sheet.Name + " Page" + (j + 1) + ".out.emf";
            sr.ToImage(j, EmfSheetName);

            var bytes = File.ReadAllBytes(EmfSheetName);
            var emfImage = pres.Images.AddImage(bytes);
            ISlide slide = pres.Slides.AddEmptySlide(pres.LayoutSlides.GetByType(SlideLayoutType.Blank));
            slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, pres.SlideSize.Size.Width, pres.SlideSize.Size.Height, emfImage);
        }

        pres.Save(dataDir + "Saved.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}
```

## **이미지 컬렉션의 이미지 교체**

Aspose.Slides를 사용하면 프레젠테이션 이미지 컬렉션(슬라이드 도형이 사용하는 이미지 포함)에 저장된 이미지를 교체할 수 있습니다. 이 섹션에서는 컬렉션의 이미지를 업데이트하는 여러 접근 방식을 보여줍니다. API는 원시 바이트 데이터, [IImage](https://reference.aspose.com/slides/ko/net/aspose.slides/iimage/) 인스턴스, 또는 컬렉션에 이미 존재하는 다른 이미지를 사용하여 이미지를 교체하는 간단한 메서드를 제공합니다.

1. [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/) 클래스를 사용하여 이미지를 포함한 프레젠테이션 파일을 로드합니다.
1. 파일에서 새 이미지를 바이트 배열로 로드합니다.
1. 바이트 배열을 사용하여 대상 이미지를 새 이미지로 교체합니다.
1. 두 번째 접근 방식에서는 이미지를 [IImage](https://reference.aspose.com/slides/ko/net/aspose.slides/iimage/) 객체에 로드한 후 해당 객체를 사용하여 대상 이미지를 교체합니다.
1. 세 번째 접근 방식에서는 프레젠테이션 이미지 컬렉션에 이미 존재하는 이미지를 사용하여 대상 이미지를 교체합니다.
1. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.
```cs
// 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
using Presentation presentation = new Presentation("sample.pptx");

// 첫 번째 방법.
byte[] imageData = File.ReadAllBytes("image0.jpeg");
IPPImage oldImage = presentation.Images[0];
oldImage.ReplaceImage(imageData);

// 두 번째 방법.
using IImage newImage = Images.FromFile("image1.png");
oldImage = presentation.Images[1];
oldImage.ReplaceImage(newImage);

// 세 번째 방법.
oldImage = presentation.Images[2];
oldImage.ReplaceImage(presentation.Images[3]);

// 프레젠테이션을 파일에 저장합니다.
presentation.Save("output.pptx", SaveFormat.Pptx);
```

{{% alert title="정보" color="info" %}}
Aspose 무료 [Text to GIF](https://products.aspose.app/slides/ko/text-to-gif) 변환기를 사용하면 텍스트를 손쉽게 애니메이션화하고, 텍스트에서 GIF를 만들 수 있습니다. 
{{% /alert %}}

## **FAQ**

**삽입 후 원본 이미지 해상도가 유지됩니까?**

예. 원본 픽셀은 보존되지만 최종 모습은 슬라이드에서 [picture](/slides/ko/net/picture-frame/)가 어떻게 스케일링되는지와 저장 시 적용되는 압축에 따라 달라집니다.

**수십 개의 슬라이드에서 동일한 로고를 한 번에 교체하는 가장 좋은 방법은 무엇입니까?**

마스터 슬라이드나 레이아웃에 로고를 배치하고 프레젠테이션 이미지 컬렉션에서 교체하면 해당 리소스를 사용하는 모든 요소에 변경 사항이 전파됩니다.

**삽입된 SVG를 편집 가능한 형태로 변환할 수 있나요?**

예. SVG를 형태 그룹으로 변환하면 개별 파트가 표준 형태 속성을 사용하여 편집할 수 있게 됩니다.

**여러 슬라이드에 한 번에 그림을 배경으로 설정하려면 어떻게 해야 하나요?**

마스터 슬라이드 또는 해당 레이아웃에 [이미지를 배경으로 지정](/slides/ko/net/presentation-background/)하면 해당 마스터/레이아웃을 사용하는 모든 슬라이드가 배경을 상속받습니다.

**많은 그림으로 인해 프레젠테이션 파일 크기가 급증하는 것을 어떻게 방지하나요?**

중복된 이미지 대신 단일 이미지 리소스를 재사용하고, 적절한 해상도를 선택하며, 저장 시 압축을 적용하고, 반복되는 그래픽은 가능한 경우 마스터에 유지하십시오.