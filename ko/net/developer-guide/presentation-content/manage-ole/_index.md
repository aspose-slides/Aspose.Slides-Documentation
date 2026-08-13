---
title: .NET에서 프레젠테이션의 OLE 개체 관리
linktitle: OLE 관리
type: docs
weight: 40
url: /ko/net/manage-ole/
keywords:
- OLE 개체
- 객체 연결 및 포함
- OLE 추가
- OLE 삽입
- 개체 추가
- 개체 삽입
- 파일 추가
- 파일 삽입
- 연결된 개체
- 연결된 파일
- OLE 변경
- OLE 아이콘
- OLE 제목
- OLE 추출
- 개체 추출
- 파일 추출
- PowerPoint
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET을 사용하여 PowerPoint 및 OpenDocument 파일에서 OLE 개체 관리를 최적화합니다. OLE 콘텐츠를 원활하게 삽입, 업데이트 및 내보내기합니다."
---
## **소개**

{{% alert title="Info" color="info" %}}

OLE(Object Linking & Embedding)는 하나의 응용 프로그램에서 만든 데이터와 개체를 연결 또는 삽입을 통해 다른 응용 프로그램에 배치할 수 있게 해 주는 Microsoft 기술입니다. 

{{% /alert %}} 

MS Excel에서 만든 차트를 생각해 보세요. 그 차트를 PowerPoint 슬라이드에 삽입하면 해당 Excel 차트는 OLE 개체로 간주됩니다. 

- OLE 개체는 아이콘 형태로 표시될 수 있습니다. 이 경우 아이콘을 더블 클릭하면 차트가 연결된 응용 프로그램(Excel)에서 열리거나 개체를 열거나 편집할 응용 프로그램을 선택하라는 메시지가 표시됩니다. 
- OLE 개체가 차트와 같은 실제 내용을 표시할 수도 있습니다. 이 경우 차트가 PowerPoint에서 활성화되고 차트 인터페이스가 로드되어 PowerPoint 내에서 차트 데이터를 수정할 수 있습니다.

[Aspose.Slides for .NET](https://products.aspose.com/slides/ko/net/)를 사용하면 OLE 개체 프레임([OleObjectFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/oleobjectframe))으로 슬라이드에 OLE 개체를 삽입할 수 있습니다.

## **슬라이드에 OLE 개체 프레임 추가**

Microsoft Excel에서 차트를 이미 만든 상태이고 Aspose.Slides for .NET을 사용해 해당 차트를 OLE 개체 프레임으로 슬라이드에 삽입하려면 다음과 같이 하면 됩니다.

1. [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation) 클래스의 인스턴스를 생성합니다.  
2. 인덱스를 통해 슬라이드 참조를 가져옵니다.  
3. Excel 파일을 바이트 배열로 읽어들입니다.  
4. 바이트 배열 및 OLE 개체에 대한 기타 정보를 포함하여 슬라이드에 [OleObjectFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/oleobjectframe)을 추가합니다.  
5. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.  

아래 예제에서는 Aspose.Slides for .NET을 사용해 Excel 파일의 차트를 [OleObjectFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/oleobjectframe)으로 슬라이드에 추가했습니다.  
**Note**: [OleEmbeddedDataInfo](https://reference.aspose.com/slides/ko/net/aspose.slides.dom.ole/oleembeddeddatainfo/) 생성자는 두 번째 매개변수로 삽입 가능한 개체 확장자를 받습니다. 이 확장자는 PowerPoint가 파일 유형을 올바르게 해석하고 해당 OLE 개체를 열 적절한 응용 프로그램을 선택하도록 도와줍니다.

```csharp 
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    SizeF slideSize = presentation.SlideSize.Size;
    ISlide slide = presentation.Slides[0];

    // OLE 개체에 대한 데이터를 준비합니다.
    byte[] fileData = File.ReadAllBytes("book.xlsx");
    IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(fileData, "xlsx");

    // 슬라이드에 OLE 개체 프레임을 추가합니다.
    slide.Shapes.AddOleObjectFrame(0, 0, slideSize.Width, slideSize.Height, dataInfo);

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

### **연결된 OLE 개체 프레임 추가**

Aspose.Slides for .NET을 사용하면 데이터를 삽입하지 않고 파일에 대한 링크만으로 [OleObjectFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/oleobjectframe)을 추가할 수 있습니다.

다음 C# 코드는 연결된 Excel 파일을 사용해 슬라이드에 [OleObjectFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/oleobjectframe)을 추가하는 방법을 보여줍니다:

```csharp 
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // 연결된 Excel 파일로 OLE 개체 프레임을 추가합니다.
    slide.Shapes.AddOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **OLE 개체 프레임 접근**

슬라이드에 OLE 개체가 이미 삽입되어 있다면 다음과 같이 쉽게 찾아 접근할 수 있습니다.

1. [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation) 클래스의 인스턴스를 생성해 삽입된 OLE 개체가 포함된 프레젠테이션을 로드합니다.  
2. 인덱스를 사용해 슬라이드 참조를 가져옵니다.  
3. [OleObjectFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/oleobjectframe) 형태에 접근합니다.  
   예제에서는 첫 번째 슬라이드에 하나의 도형만 있는 PPTX를 사용했습니다. 그 도형을 [IOleObjectFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/ioleobjectframe)으로 *캐스트*했습니다. 이것이 접근하고자 하는 OLE 개체 프레임입니다.  
4. OLE 개체 프레임에 접근한 후에는 원하는 작업을 수행할 수 있습니다.

아래 예제에서는 슬라이드에 삽입된 OLE 개체 프레임(Excel 차트 개체)과 해당 파일 데이터를 접근합니다.

```csharp 
using Aspose.Slides;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // 첫 번째 도형을 OLE 개체 프레임으로 가져옵니다.
    IOleObjectFrame oleFrame = slide.Shapes[0] as IOleObjectFrame;

    if (oleFrame != null)
    {
        // 삽입된 파일 데이터를 가져옵니다.
        byte[] fileData = oleFrame.EmbeddedData.EmbeddedFileData;

        // 삽입된 파일의 확장자를 가져옵니다.
        string fileExtension = oleFrame.EmbeddedData.EmbeddedFileExtension;

        // ...
    }
}
```

### **연결된 OLE 개체 프레임 속성 확인**

Aspose.Slides를 사용하면 연결된 OLE 개체 프레임 속성을 확인할 수 있습니다.

다음 C# 코드는 OLE 개체가 연결되어 있는지 확인하고 연결된 파일 경로를 가져오는 방법을 보여줍니다:

```csharp
using Aspose.Slides;

using (Presentation presentation = new Presentation("sample.ppt"))
{
    ISlide slide = presentation.Slides[0];

    // 첫 번째 도형을 OLE 개체 프레임으로 가져옵니다.
    IOleObjectFrame oleFrame = slide.Shapes[0] as IOleObjectFrame;

    // OLE 개체가 연결되어 있는지 확인합니다.
    if (oleFrame != null && oleFrame.IsObjectLink)
    {
        // 연결된 파일의 전체 경로를 출력합니다.
        Console.WriteLine("OLE object frame is linked to: " + oleFrame.LinkPathLong);

        // 존재하는 경우 연결된 파일의 상대 경로를 출력합니다.
        // 상대 경로는 PPT 프레젠테이션에서만 포함될 수 있습니다.
        if (!string.IsNullOrEmpty(oleFrame.LinkPathRelative))
        {
            Console.WriteLine("OLE object frame relative path: " + oleFrame.LinkPathRelative);
        }
    }
}
```

## **OLE 개체 데이터 변경**

{{% alert color="info" %}} 

이 섹션의 코드 예제는 [Aspose.Cells for .NET](/cells/net/)을 사용합니다.

{{% /alert %}}

슬라이드에 OLE 개체가 이미 삽입되어 있다면 다음과 같이 해당 개체에 접근하고 데이터를 변경할 수 있습니다.

1. [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation) 클래스의 인스턴스를 생성해 삽입된 OLE 개체가 포함된 프레젠테이션을 로드합니다.  
2. 인덱스를 통해 슬라이드 참조를 가져옵니다.  
3. [OLEObjectFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/oleobjectframe) 형태에 접근합니다.  
   예제에서는 첫 번째 슬라이드에 하나의 도형만 있는 PPTX를 사용했습니다. 그 도형을 [IOleObjectFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/ioleobjectframe)으로 *캐스트*했습니다. 이것이 접근하고자 하는 OLE 개체 프레임입니다.  
4. OLE 개체 프레임에 접근한 후에는 원하는 작업을 수행할 수 있습니다.  
5. `Workbook` 객체를 생성하고 OLE 데이터를 접근합니다.  
6. 원하는 `Worksheet`에 접근해 데이터를 수정합니다.  
7. 업데이트된 `Workbook`을 스트림에 저장합니다.  
8. 스트림으로 OLE 개체 데이터를 교체합니다.  

아래 예제에서는 슬라이드에 삽입된 OLE 개체 프레임(Excel 차트 개체)에 접근하고 파일 데이터를 수정해 차트 데이터를 업데이트합니다.

```csharp 
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // 첫 번째 도형을 OLE 개체 프레임으로 가져옵니다.
    IOleObjectFrame oleFrame = slide.Shapes[0] as IOleObjectFrame;

    if (oleFrame != null)
    {
        using (MemoryStream oleStream = new MemoryStream(oleFrame.EmbeddedData.EmbeddedFileData))
        {
            // OLE 개체 데이터를 Workbook 객체로 읽습니다.
            Aspose.Cells.Workbook workbook = new Aspose.Cells.Workbook(oleStream);

            using (MemoryStream newOleStream = new MemoryStream())
            {
                // 워크북 데이터를 수정합니다.
                workbook.Worksheets[0].Cells[0, 4].PutValue("E");
                workbook.Worksheets[0].Cells[1, 4].PutValue(12);
                workbook.Worksheets[0].Cells[2, 4].PutValue(14);
                workbook.Worksheets[0].Cells[3, 4].PutValue(15);

                Aspose.Cells.OoxmlSaveOptions fileOptions = new Aspose.Cells.OoxmlSaveOptions(Aspose.Cells.SaveFormat.Xlsx);
                workbook.Save(newOleStream, fileOptions);

                // OLE 프레임 개체 데이터를 변경합니다.
                IOleEmbeddedDataInfo newData = new OleEmbeddedDataInfo(newOleStream.ToArray(), oleFrame.EmbeddedData.EmbeddedFileExtension);
                oleFrame.SetEmbeddedData(newData);
            }
        }
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **슬라이드에 다른 파일 형식 삽입**

Excel 차트 외에도 Aspose.Slides for .NET을 사용하면 HTML, PDF, ZIP 등 다양한 파일을 슬라이드에 개체로 삽입할 수 있습니다. 사용자가 삽입된 개체를 더블 클릭하면 해당 프로그램에서 자동으로 열리거나, 적절한 프로그램을 선택하라는 프롬프트가 표시됩니다.

다음 C# 코드는 HTML과 ZIP 파일을 슬라이드에 삽입하는 방법을 보여줍니다:

```c#
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    byte[] htmlData = File.ReadAllBytes("sample.html");
    IOleEmbeddedDataInfo htmlDataInfo = new OleEmbeddedDataInfo(htmlData, "html");
    IOleObjectFrame htmlOleFrame = slide.Shapes.AddOleObjectFrame(150, 120, 50, 50, htmlDataInfo);
    htmlOleFrame.IsObjectIcon = true;

    byte[] zipData = File.ReadAllBytes("sample.zip");
    IOleEmbeddedDataInfo zipDataInfo = new OleEmbeddedDataInfo(zipData, "zip");
    IOleObjectFrame zipOleFrame = slide.Shapes.AddOleObjectFrame(150, 220, 50, 50, zipDataInfo);
    zipOleFrame.IsObjectIcon = true;

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **삽입된 개체의 파일 형식 지정**

프레젠테이션 작업 중에 오래된 OLE 개체를 새로운 개체로 교체하거나 지원되지 않는 OLE 개체를 지원되는 개체로 바꿔야 할 때가 있습니다. Aspose.Slides for .NET을 사용하면 삽입된 개체의 파일 형식을 지정해 OLE 프레임 데이터 또는 확장자를 업데이트할 수 있습니다.

다음 C# 코드는 삽입된 OLE 개체의 파일 형식을 `zip`으로 설정하는 방법을 보여줍니다:

```c#
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IOleObjectFrame oleFrame = (IOleObjectFrame)slide.Shapes[0];

    string fileExtension = oleFrame.EmbeddedData.EmbeddedFileExtension;
    byte[] fileData = oleFrame.EmbeddedData.EmbeddedFileData;

    Console.WriteLine($"Current embedded file extension is: {fileExtension}");

    // 파일 형식을 ZIP으로 변경합니다.
    oleFrame.SetEmbeddedData(new OleEmbeddedDataInfo(fileData, "zip"));

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **삽입된 개체의 아이콘 이미지와 제목 설정**

OLE 개체를 삽입하면 아이콘 이미지로 구성된 미리보기가 자동으로 추가됩니다. 사용자는 OLE 개체에 접근하거나 열기 전에 이 미리보기를 보게 됩니다. 특정 이미지와 텍스트를 미리보기 요소로 사용하려면 Aspose.Slides for .NET을 사용해 아이콘 이미지와 제목을 설정할 수 있습니다.

다음 C# 코드는 삽입된 개체에 대한 아이콘 이미지와 제목을 설정하는 방법을 보여줍니다: 

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IOleObjectFrame oleFrame = (IOleObjectFrame)slide.Shapes[0];

    // 프레젠테이션 리소스에 이미지를 추가합니다.
    byte[] imageData = File.ReadAllBytes("image.png");
    IPPImage oleImage = presentation.Images.AddImage(imageData);

    // OLE 미리보기를 위한 제목과 이미지를 설정합니다.
    oleFrame.SubstitutePictureTitle = "My title";
    oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
    oleFrame.IsObjectIcon = true;

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **OLE 개체 프레임 크기 및 위치 자동 변경 방지**

연결된 OLE 개체를 프레젠테이션 슬라이드에 추가한 후 PowerPoint에서 프레젠테이션을 열면 링크를 업데이트하라는 메시지가 나타날 수 있습니다. "Update Links" 버튼을 클릭하면 PowerPoint가 연결된 OLE 개체 데이터를 최신화하고 미리보기를 새로 고치면서 OLE 개체 프레임의 크기와 위치가 변경될 수 있습니다. PowerPoint가 개체 데이터를 업데이트하도록 요청하는 것을 방지하려면 [IOleObjectFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/ioleobjectframe/) 인터페이스의 `UpdateAutomatic` 속성을 `false`로 설정합니다:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    IOleObjectFrame oleFrame = (IOleObjectFrame)presentation.Slides[0].Shapes[0];

    // PowerPoint가 링크를 업데이트할 때 OLE 개체 프레임의 크기와 위치를 유지합니다.
    oleFrame.UpdateAutomatic = false;

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **삽입된 파일 추출**

Aspose.Slides for .NET을 사용하면 슬라이드에 OLE 개체로 삽입된 파일을 다음과 같이 추출할 수 있습니다.
1. 추출하려는 OLE 개체가 포함된 [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation) 클래스 인스턴스를 생성합니다.  
2. 프레젠테이션의 모든 도형을 순회하며 [OLEObjectFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/oleobjectframe) 도형에 접근합니다.  
3. OLE 개체 프레임에서 삽입된 파일 데이터를 읽어 디스크에 저장합니다.  

다음 C# 코드는 슬라이드에 삽입된 파일을 OLE 개체로 추출하는 방법을 보여줍니다:

```c#
using Aspose.Slides;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    for (int index = 0; index < slide.Shapes.Count; index++)
    {
        IShape shape = slide.Shapes[index];
        IOleObjectFrame oleFrame = shape as IOleObjectFrame;

        if (oleFrame != null)
        {
            byte[] fileData = oleFrame.EmbeddedData.EmbeddedFileData;
            string fileExtension = oleFrame.EmbeddedData.EmbeddedFileExtension;

            string filePath = $"OLE_object_{index}{fileExtension}";
            File.WriteAllBytes(filePath, fileData);
        }
    }
}
```

## **FAQ**

### 슬라이드를 PDF/이미지로 내보낼 때 OLE 콘텐츠가 렌더링되나요?

슬라이드에 표시되는 것은 아이콘/대체 이미지(미리보기)입니다. “실시간” OLE 콘텐츠는 렌더링 중에 실행되지 않으며, 필요하다면 자체 미리보기 이미지를 설정해 내보낸 PDF에서 원하는 모습을 보이도록 할 수 있습니다.

### PowerPoint에서 사용자가 OLE 개체를 이동/편집하지 못하도록 슬라이드에서 잠그려면 어떻게 해야 하나요?

도형을 잠급니다: Aspose.Slides는 [shape-level locks](/slides/ko/net/applying-protection-to-presentation/) 기능을 제공합니다. 이는 암호화가 아니라 실수로 인한 편집 및 이동을 방지합니다.

### 연결된 Excel 개체를 열 때 개체가 “점프”하거나 크기가 변하는 이유는 무엇인가요?

PowerPoint가 연결된 OLE의 미리보기를 새로 고칠 수 있습니다. 안정적인 표시를 위해서는 [Worksheet Resizing 해결책](/slides/ko/net/working-solution-for-worksheet-resizing/)을 따라 프레임을 범위에 맞추거나 범위를 고정 프레임에 맞게 스케일링하고 적절한 대체 이미지를 설정합니다.

### PPTX 형식에서 연결된 OLE 개체의 상대 경로가 유지되나요?

PPTX에서는 “상대 경로” 정보가 제공되지 않고 전체 경로만 저장됩니다. 상대 경로는 이전 PPT 형식에만 존재합니다. 이동성을 위해 신뢰할 수 있는 절대 경로/액세스 가능한 URI를 사용하거나 삽입하는 것이 좋습니다.