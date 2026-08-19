---
title: .NET 프레젠테이션에서 이미지 관리 최적화
linktitle: 이미지 관리
type: docs
weight: 10
url: /ko/net/image/
keywords:
- 이미지 추가
- 그림 추가
- 이미지 교체
- 이미지 컬렉션
- 그림 프레임
- 링크된 이미지
- 배경
- PNG 추가
- JPG 추가
- SVG 추가
- SVG를 도형으로 변환
- 외부 SVG 리소스
- PowerPoint
- OpenDocument
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET를 사용하여 PowerPoint 및 OpenDocument 프레젠테이션에서 래스터 및 SVG 이미지를 추가, 재사용, 링크, 교체 및 관리하는 방법을 배우십시오."
---
## **소개**

Aspose.Slides for .NET은 이미지를 다루는 여러 방법을 제공하며, 각 방법은 다른 목적을 수행합니다. 이미지를 프레젠테이션에 저장하고, 그림 프레임에 표시하고, 슬라이드 배경으로 사용하고, 외부 이미지에 링크하고, 공유 이미지 리소스를 교체하거나, SVG 내용을 편집 가능한 도형으로 변환할 수 있습니다.

이 문서는 이미지 리소스와 프레젠테이션 전반에서의 사용 방법에 초점을 맞춥니다. 개별 그림 프레임에 적용되는 자르기, 투명도, 효과, 늘리기 및 기타 서식에 대해서는 [Picture Frame](/slides/ko/net/picture-frame/)을 참고하십시오.

## **이미지 모델 이해**

다음 API 개념은 서로 밀접하게 관련되어 있지만 교환 가능하지 않습니다:

- 프레젠테이션에서 사용되는 이미지 리소스를 저장하는 [프레젠테이션 이미지 컬렉션](https://reference.aspose.com/slides/ko/net/aspose.slides/iimagecollection/). 이미지를 추가하려면 [ImageCollection.AddImage](https://reference.aspose.com/slides/ko/net/aspose.slides/imagecollection/addimage/)을 사용하고 [IPPImage](https://reference.aspose.com/slides/ko/net/aspose.slides/ippimage/) 리소스를 얻습니다.
- [그림 프레임](https://reference.aspose.com/slides/ko/net/aspose.slides/ipictureframe/)은 슬라이드, 레이아웃 또는 마스터에 이미지를 표시하는 도형입니다. 이미지 리소스를 슬라이드에 배치하려면 [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/ishapecollection/addpictureframe/)을 사용합니다.
- 슬라이드 배경은 도형이 아니라 슬라이드 채우기의 일부로 이미지를 사용합니다. 따라서 그림 프레임처럼 동작하지 않습니다.
- [IPPImage.ReplaceImage](https://reference.aspose.com/slides/ko/net/aspose.slides/ippimage/replaceimage/)은 이미지 리소스를 교체합니다. 여러 프레젠테이션 요소가 해당 리소스를 사용한다면 모두 교체된 리소스를 사용하게 됩니다.
- SVG를 도형으로 변환하면 편집 가능한 슬라이드 도형이 생성됩니다. 변환 후에는 콘텐츠가 단일 그림 리소스로 관리되지 않습니다.

일반적인 작업 흐름은 다음과 같습니다: 이미지 데이터를 이미지 컬렉션에 추가하고, [IPPImage](https://reference.aspose.com/slides/ko/net/aspose.slides/ippimage/)를 받아서 하나 이상의 그림 프레임이나 채우기에 해당 리소스를 사용합니다.

## **임베디드 이미지 추가**

로컬 이미지를 삽입하려면 파일을 읽고, 데이터를 이미지 컬렉션에 추가한 뒤 반환된 `IPPImage`를 사용하는 그림 프레임을 생성합니다.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var imageData = File.ReadAllBytes("photo.png");
var image = presentation.Images.AddImage(imageData);

var slide = presentation.Slides[0];
slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, image);

presentation.Save("presentation.pptx", SaveFormat.Pptx);
```

이 방식으로 추가된 이미지는 프레젠테이션에 임베드되므로, 결과 파일은 원본 이미지 파일이 계속 존재할 필요가 없습니다.

### **웹에서 이미지 추가**

이미지가 HTTP 또는 HTTPS를 통해 제공되는 경우 `HttpClient`로 바이트를 다운로드하고, 프레젠테이션 이미지 컬렉션에 추가한 뒤 로컬 이미지와 동일한 방식으로 반환된 이미지 리소스를 사용합니다.

```csharp
using System;
using System.Net.Http;
using Aspose.Slides;
using Aspose.Slides.Export;

var imageUri = new Uri("https://example.com/image.png");
using var httpClient = new HttpClient();
var imageData = await httpClient.GetByteArrayAsync(imageUri);

using var presentation = new Presentation();

var image = presentation.Images.AddImage(imageData);
var slide = presentation.Slides[0];
slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, image);

presentation.Save("presentation-from-web.pptx", SaveFormat.Pptx);
```

장시간 실행되는 애플리케이션에서는 요청마다 새 인스턴스를 만들기보다 `HttpClient`를 재사용하십시오. 또한 신뢰할 수 없는 소스일 경우 원격 URL, 응답 크기 및 콘텐츠 유형을 검증하십시오.

## **슬라이드 간 이미지 재사용**

같은 이미지를 여러 번 사용해야 할 경우 프레젠테이션에 한 번만 추가하고, 추가적인 그림 프레임을 만들 때 반환된 [IPPImage](https://reference.aspose.com/slides/ko/net/aspose.slides/ippimage/)을 재사용하십시오. 이렇게 하면 동일한 소스 데이터를 반복해서 로드하는 비용을 피하고, 공유 이미지 리소스와 사용 위치 간의 관계를 명확히 할 수 있습니다.

많은 슬라이드에 자동으로 나타나야 하는 로고와 같은 그래픽은 각각의 슬라이드에 동일한 도형을 추가하기보다 [슬라이드 마스터](/slides/ko/net/slide-master/) 또는 레이아웃에 그림 프레임을 배치하는 것이 좋습니다.

## **이미지를 슬라이드 배경으로 사용**

배경 이미지는 슬라이드 채우기에 할당되며, 그림 프레임 도형으로 추가되지 않습니다. 이는 그림이 슬라이드 배경 전체를 가려야 하고 일반 슬라이드 객체처럼 조작되지 않아야 할 때 유용합니다.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("background.jpg");
var image = presentation.Images.AddImage(imageData);
slide.Background.Type = BackgroundType.OwnBackground;
slide.Background.FillFormat.FillType = FillType.Picture;
slide.Background.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
slide.Background.FillFormat.PictureFillFormat.Picture.Image = image;

presentation.Save("background-image.pptx", SaveFormat.Pptx);
```

마스터 및 레이아웃 배경을 포함한 추가 배경 옵션은 [Presentation Background](/slides/ko/net/presentation-background/)을 참조하십시오.

## **임베디드 이미지와 링크된 이미지**

임베디드 이미지와 링크된 이미지는 이동성 및 파일 크기 측면에서 서로 다른 절충점을 가집니다:

- **임베디드 이미지:** 이미지 데이터가 프레젠테이션 내부에 저장됩니다. 프레젠테이션이 자체 포함되지만 파일 크기에 이미지 데이터가 포함됩니다.
- **링크된 이미지:** 프레젠테이션이 외부 이미지에 대한 경로나 URL을 저장합니다. 이는 프레젠테이션 크기를 줄일 수 있지만, 외부 리소스가 열거나 렌더링될 때 접근 가능해야 합니다.

링크된 그림은 이미지 데이터를 임베드하지 않고 [ISlidesPicture.LinkPathLong](https://reference.aspose.com/slides/ko/net/aspose.slides/islidespicture/linkpathlong/)을 통해 외부 경로나 URL을 지정하여 만들 수 있습니다.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, null);
pictureFrame.PictureFormat.Picture.LinkPathLong = "https://example.com/image.png";

presentation.Save("linked-image.pptx", SaveFormat.Pptx);
```

외부 리소스에 신뢰할 수 있는 접근이 보장되는 배포 환경에서만 링크된 이미지를 사용하십시오. 오프라인으로 작동하거나 시스템 간 이동이 필요한 프레젠테이션에서는 일반적으로 임베디드 이미지가 더 안전합니다.

## **SVG 이미지 작업**

SVG는 벡터 형식이므로 아이콘, 다이어그램 및 래스터 이미지와 달리 디테일 손실 없이 확대·축소할 수 있는 그래픽에 유용합니다. Aspose.Slides는 SVG를 이미지 리소스로뿐 아니라 편집 가능한 슬라이드 도형의 소스로도 지원합니다.

### **SVG를 이미지로 추가**

[SvgImage](https://reference.aspose.com/slides/ko/net/aspose.slides/svgimage/)을 생성하고 이미지 컬렉션에 추가한 뒤, 결과 이미지 리소스를 그림 프레임에 배치합니다.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

var svgContent = File.ReadAllText("icon.svg");
var svgImage = new SvgImage(svgContent);

using var presentation = new Presentation();

var image = presentation.Images.AddImage(svgImage);
var slide = presentation.Slides[0];
slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 20, 200, 200, image);

presentation.Save("svg-image.pptx", SaveFormat.Pptx);
```

### **외부 리소스를 가진 SVG 파일**

SVG는 외부 이미지, 스타일시트 또는 글꼴을 참조할 수 있습니다. 이러한 경우 [SvgImage](https://reference.aspose.com/slides/ko/net/aspose.slides/svgimage/)은 [IExternalResourceResolver](https://reference.aspose.com/slides/ko/net/aspose.slides.import/iexternalresourceresolver/)와 기본 URI를 받는 생성자를 제공합니다. 리졸버는 상대 URI를 허용된 절대 URI로 매핑하고 요청된 리소스에 대한 스트림을 반환합니다.

리졸버는 SVG를 처리하는 동안 외부 리소스를 사용할 수 있게 하지만, SVG 자체를 자체 포함 문서로 재작성하지는 않습니다. SVG를 이동 가능하게 유지해야 한다면, 예를 들어 `data:` URI를 사용해 링크된 이미지를 임베드하는 방식을 고려하십시오.

신뢰할 수 없는 소스에서 SVG 파일을 가져오는 경우, 리졸버가 접근할 수 있는 스킴, 파일 위치 및 호스트를 제한하십시오. 네트워크 리졸버에는 타임아웃, 응답 크기 제한 및 콘텐츠 검증도 적용해야 합니다.

### **SVG를 편집 가능한 도형으로 변환**

Aspose.Slides는 SVG를 편집 가능한 슬라이드 도형 그룹으로 변환할 수 있으며, 이는 PowerPoint에서 제공하는 해당 명령과 유사합니다.

![PowerPoint Popup Menu](img_01_01.png)

[ISvgImage](https://reference.aspose.com/slides/ko/net/aspose.slides/isvgimage/)을 인수로 받는 [IShapeCollection.AddGroupShape](https://reference.aspose.com/slides/ko/net/aspose.slides/ishapecollection/addgroupshape/) 오버로드를 사용하여 변환을 수행합니다.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

var svgContent = File.ReadAllText("diagram.svg");
var svgImage = new SvgImage(svgContent);

using var presentation = new Presentation();

var slideSize = presentation.SlideSize.Size;
var slide = presentation.Slides[0];
slide.Shapes.AddGroupShape(svgImage, 0, 0, slideSize.Width, slideSize.Height);

presentation.Save("editable-svg-shapes.pptx", SaveFormat.Pptx);
```

SVG를 도형으로 변환하는 것은 개별 벡터 요소를 PowerPoint 도형으로 편집해야 할 때 사용합니다. SVG를 단순히 표시만 하면 이미지로 유지하는 것이 더 간단하고 많은 개별 도형을 생성하는 것을 방지합니다.

## **기존 이미지 리소스 교체**

기존 이미지 리소스를 교체하려면 [IPPImage.ReplaceImage](https://reference.aspose.com/slides/ko/net/aspose.slides/ippimage/replaceimage/)를 사용하십시오. 이는 로고와 같은 공유 그래픽을 교체할 때 특히 유용합니다.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");

var imageToReplace = presentation.Images[0];
imageToReplace.ReplaceImage(File.ReadAllBytes("new-logo.png"));

presentation.Save("output.pptx", SaveFormat.Pptx);
```

여러 그림 프레임, 배경, 마스터 또는 레이아웃이 동일한 이미지 리소스를 사용하고 있다면 해당 리소스를 교체함으로써 모든 사용 위치가 업데이트됩니다. 하나의 그림 프레임만 변경해야 할 경우 공유 리소스를 교체하기보다 해당 프레임에 다른 이미지를 할당하십시오.

`ReplaceImage`는 또한 [IImage](https://reference.aspose.com/slides/ko/net/aspose.slides/iimage/) 또는 다른 [IPPImage](https://reference.aspose.com/slides/ko/net/aspose.slides/ippimage/)을 인수로 받는 오버로드를 제공합니다.

## **실용적인 이미지 관리 가이드**

### **프레젠테이션 크기 제어**

큰 래스터 이미지는 프레젠테이션을 불필요하게 크게 만들 수 있습니다. 표시될 크기에 맞는 해상도의 원본 이미지를 사용하고, 가능한 경우 공유 이미지 리소스를 재사용하며, 동일한 고해상도 그래픽을 중복 임베드하지 않도록 하십시오.

이미 그림 프레임에 이미 배치된 래스터 사진은 [IPictureFillFormat.CompressImage](https://reference.aspose.com/slides/ko/net/aspose.slides/ipicturefillformat/compressimage/)을 사용해 선택된 해상도와 자르기 설정에 따라 이미지 데이터를 축소할 수 있습니다. 이는 이미지 컬렉션 관리가 아니라 그림 프레임 처리이므로 관련 서식 작업은 [Picture Frame](/slides/ko/net/picture-frame/)을 참고하십시오.

### **임베디드와 링크된 콘텐츠 선택**

임베드하면 모든 이미지 데이터가 파일에 포함되어 프레젠테이션이 이동성이 높아집니다. 링크는 파일 크기를 줄일 수 있지만 외부 종속성을 도입합니다. 외부 종속성이 허용되고 안정적일 경우에만 링크를 사용하십시오.

### **공유 브랜딩 재사용**

반복되는 로고, 워터마크 또는 장식 그래픽은 하나의 이미지 리소스를 사용해 재사용하십시오. 그래픽이 슬라이드 내용보다 디자인에 속한다면 마스터나 레이아웃에 배치해 해당 슬라이드가 자동으로 상속하도록 합니다.

### **SVG 리소스를 포터블하게 유지**

자체 포함 SVG는 외부 파일이나 네트워크 리소스에 의존하는 SVG보다 이동 및 일관된 렌더링이 쉽습니다. 가능하면 SVG를 가져오기 전에 필요한 리소스를 임베드하고, 개별 벡터 요소를 편집해야 할 때만 SVG를 도형으로 변환하십시오.

### **최신 크로스 플랫폼 이미지 API 사용**

새 .NET 코드를 작성할 때는 `System.Drawing.Image` 또는 `Bitmap` 대신 Aspose.Slides [IImage](https://reference.aspose.com/slides/ko/net/aspose.slides/iimage/) 및 [Images](https://reference.aspose.com/slides/ko/net/aspose.slides/images/) API를 사용하십시오. 마이그레이션 가이드는 [Modern API](/slides/ko/net/modern-api/)를 확인하십시오.

WMF 및 EMF는 특별한 고려가 필요합니다. 이러한 형식을 [IImage](https://reference.aspose.com/slides/ko/net/aspose.slides/iimage/)를 통해 전달하면 [ImageCollection.AddImage](https://reference.aspose.com/slides/ko/net/aspose.slides/imagecollection/addimage/)가 메타파일을 래스터 PNG로 변환한 후 삽입합니다. 메타파일 데이터를 보존해야 한다면 스트림 기반 [ImageCollection.AddImage](https://reference.aspose.com/slides/ko/net/aspose.slides/imagecollection/addimage/) 오버로드를 사용하십시오. 스프레드시트 등에서 EMF 콘텐츠를 생성하는 경우는 별도 통합 워크플로이며 본 문서 범위에 포함되지 않습니다.

## **FAQ**

**이미지 컬렉션과 그림 프레임의 차이점은 무엇인가요?**

이미지 컬렉션은 재사용 가능한 이미지 리소스를 저장합니다. 그림 프레임은 해당 리소스 중 하나를 표시하고 자르기, 효과와 같은 그림 전용 서식을 제공하는 슬라이드 도형입니다.

**전체에 동일한 로고를 교체하는 가장 좋은 방법은 무엇인가요?**

이미 로고가 하나의 이미지 리소스로 공유되고 있다면 [IPPImage.ReplaceImage](https://reference.aspose.com/slides/ko/net/aspose.slides/ippimage/replaceimage/)로 해당 리소스를 교체하십시오. 프레젠테이션 전체에 브랜딩을 적용하려면 로고를 마스터나 레이아웃에 배치하는 것도 중복 슬라이드 내용을 줄이는 방법입니다.

**링크된 이미지가 다른 컴퓨터에서 사라지는 이유는 무엇인가요?**

링크된 그림은 외부 파일이나 URL에 의존합니다. 해당 리소스에 다른 컴퓨터에서 접근할 수 없으면 링크된 이미지가 표시되지 않을 수 있습니다. 프레젠테이션이 자체 포함되어야 한다면 이미지를 임베드하십시오.

**삽입한 SVG를 PowerPoint 도형으로 편집할 수 있나요?**

예. [IShapeCollection.AddGroupShape](https://reference.aspose.com/slides/ko/net/aspose.slides/ishapecollection/addgroupshape/)을 사용해 SVG를 변환하면 결과 그룹에 편집 가능한 슬라이드 도형이 포함됩니다.

**많은 이미지를 포함한 프레젠테이션을 작게 유지하려면 어떻게 해야 하나요?**

공유 이미지 리소스를 재사용하고, 불필요하게 큰 래스터 소스를 피하며, 적절할 경우 래스터 사진을 압축하고, 반복되는 브랜딩은 마스터나 레이아웃에 배치하며, 외부 종속성이 허용될 때만 링크된 이미지를 사용하십시오.