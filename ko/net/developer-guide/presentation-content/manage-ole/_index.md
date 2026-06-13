---
title: .NET에서 프레젠테이션의 OLE 객체 관리
linktitle: OLE 관리
type: docs
weight: 40
url: /ko/net/manage-ole/
keywords:
- OLE 객체
- 객체 연결 및 포함
- OLE 추가
- OLE 삽입
- 객체 추가
- 객체 삽입
- 파일 추가
- 파일 삽입
- 연결된 객체
- 연결된 파일
- OLE 변경
- OLE 아이콘
- OLE 제목
- OLE 추출
- 객체 추출
- 파일 추출
- PowerPoint
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET을 사용하여 PowerPoint 및 OpenDocument 파일에서 OLE 객체 관리를 최적화합니다. OLE 콘텐츠를 원활하게 삽입, 업데이트 및 내보냅니다."
---
## **소개**

{{% alert title="Info" color="info" %}}

OLE(Object Linking & Embedding)는 데이터를 한 응용 프로그램에서 만든 객체를 연결하거나 포함시켜 다른 응용 프로그램에 배치할 수 있게 하는 Microsoft 기술입니다. 

{{% /alert %}} 

Microsoft Excel에서 만든 차트를 생각해 보세요. 그 차트를 PowerPoint 슬라이드에 삽입합니다. 이 Excel 차트는 OLE 객체로 간주됩니다. 

- OLE 객체는 아이콘으로 표시될 수 있습니다. 이 경우 아이콘을 더블 클릭하면 차트가 해당 응용 프로그램(Excel)에서 열리거나, 객체를 열거나 편집할 응용 프로그램을 선택하라는 메시지가 표시됩니다. 
- OLE 객체는 차트 내용과 같이 실제 내용을 표시할 수 있습니다. 이 경우 차트가 PowerPoint에서 활성화되고 차트 인터페이스가 로드되어 PowerPoint 내에서 차트 데이터를 수정할 수 있습니다. 

[Aspose.Slides for .NET](https://products.aspose.com/slides/ko/net/)는 OLE 객체를 OLE 객체 프레임([OleObjectFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/oleobjectframe))으로 슬라이드에 삽입할 수 있습니다.

## **슬라이드에 OLE 객체 프레임 추가**

Microsoft Excel에서 차트를 이미 만든 상태이며 Aspose.Slides for .NET을 사용하여 해당 차트를 OLE 객체 프레임으로 슬라이드에 삽입하려는 경우 다음과 같이 할 수 있습니다:

1. [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation) 클래스의 인스턴스를 생성합니다.  
2. 인덱스를 통해 슬라이드의 참조를 가져옵니다.  
3. Excel 파일을 바이트 배열로 읽습니다.  
4. 바이트 배열 및 OLE 객체에 대한 기타 정보를 포함하는 [OleObjectFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/oleobjectframe)를 슬라이드에 추가합니다.  
5. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.  

아래 예제에서는 Excel 파일에 있는 차트를 Aspose.Slides for .NET을 사용하여 [OleObjectFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/oleobjectframe)으로 슬라이드에 추가했습니다.  
**Note** [OleEmbeddedDataInfo](https://reference.aspose.com/slides/ko/net/aspose.slides.dom.ole/oleembeddeddatainfo/) 생성자는 두 번째 매개변수로 삽입 가능한 객체 확장자를 받습니다. 이 확장자를 통해 PowerPoint가 파일 형식을 올바르게 해석하고 해당 OLE 객체를 열 적절한 응용 프로그램을 선택합니다.

```csharp 
using (Presentation presentation = new Presentation())
{
    SizeF slideSize = presentation.SlideSize.Size;
    ISlide slide = presentation.Slides[0];

    // OLE 객체용 데이터를 준비합니다.
    byte[] fileData = File.ReadAllBytes("book.xlsx");
    IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(fileData, "xlsx");

    // 슬라이드에 OLE 객체 프레임을 추가합니다.
    slide.Shapes.AddOleObjectFrame(0, 0, slideSize.Width, slideSize.Height, dataInfo);

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

### **링크된 OLE 객체 프레임 추가**

Aspose.Slides for .NET은 데이터를 포함하지 않고 파일에 대한 링크만으로도 [OleObjectFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/oleobjectframe)를 추가할 수 있습니다.

다음 C# 코드는 링크된 Excel 파일을 사용하여 슬라이드에 [OleObjectFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/oleobjectframe)를 추가하는 방법을 보여 줍니다:

```csharp 
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // 연결된 Excel 파일이 있는 OLE 객체 프레임을 추가합니다.
    slide.Shapes.AddOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **OLE 객체 프레임 접근**

슬라이드에 OLE 객체가 이미 삽입되어 있는 경우 다음과 같이 쉽게 찾거나 접근할 수 있습니다:

1. [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation) 클래스의 인스턴스를 생성하여 삽입된 OLE 객체가 포함된 프레젠테이션을 로드합니다.  
2. 인덱스를 사용하여 슬라이드의 참조를 가져옵니다.  
3. [OleObjectFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/oleobjectframe) 형태에 접근합니다. 예제에서는 첫 번째 슬라이드에 하나의 도형만 있는 이전에 만든 PPTX를 사용했습니다. 그런 다음 해당 객체를 [IOleObjectFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/ioleobjectframe)으로 *cast*했습니다. 이것이 접근하려는 OLE 객체 프레임이었습니다.  
4. OLE 객체 프레임에 접근한 후에는 원하는 모든 작업을 수행할 수 있습니다.  

아래 예제에서는 슬라이드에 삽입된 OLE 객체 프레임(Excel 차트 객체)과 해당 파일 데이터를 접근합니다.

```csharp 
using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // 첫 번째 도형을 OLE 객체 프레임으로 가져옵니다.
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

### **링크된 OLE 객체 프레임 속성 접근**

Aspose.Slides를 사용하면 링크된 OLE 객체 프레임 속성에 접근할 수 있습니다.

다음 C# 코드는 OLE 객체가 링크된 상태인지 확인하고 링크된 파일의 경로를 얻는 방법을 보여 줍니다:

```csharp
using (Presentation presentation = new Presentation("sample.ppt"))
{
    ISlide slide = presentation.Slides[0];

    // 첫 번째 도형을 OLE 객체 프레임으로 가져옵니다.
    IOleObjectFrame oleFrame = slide.Shapes[0] as IOleObjectFrame;

    // OLE 객체가 링크되어 있는지 확인합니다.
    if (oleFrame != null && oleFrame.IsObjectLink)
    {
        // 링크된 파일의 전체 경로를 출력합니다.
        Console.WriteLine("OLE object frame is linked to: " + oleFrame.LinkPathLong);

        // 존재하면 링크된 파일의 상대 경로를 출력합니다.
        // PPT 프레젠테이션만 상대 경로를 포함할 수 있습니다.
        if (!string.IsNullOrEmpty(oleFrame.LinkPathRelative))
        {
            Console.WriteLine("OLE object frame relative path: " + oleFrame.LinkPathRelative);
        }
    }
}
```

## **OLE 객체 데이터 변경**

{{% alert color="primary" %}} 

이 섹션의 코드 예제는 [Aspose.Cells for .NET](/cells/net/)을 사용합니다.

{{% /alert %}}

슬라이드에 OLE 객체가 이미 삽입되어 있는 경우 다음과 같이 해당 객체에 접근하고 데이터를 수정할 수 있습니다:

1. [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation) 클래스의 인스턴스를 생성하여 삽입된 OLE 객체가 포함된 프레젠테이션을 로드합니다.  
2. 인덱스를 통해 슬라이드의 참조를 얻습니다.  
3. [OLEObjectFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/oleobjectframe) 형태에 접근합니다. 예제에서는 첫 번째 슬라이드에 하나의 도형만 있는 이전에 만든 PPTX를 사용했습니다. 그런 다음 해당 객체를 [IOleObjectFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/ioleobjectframe)으로 *cast*했습니다. 이것이 접근하려는 OLE 객체 프레임이었습니다.  
4. OLE 객체 프레임에 접근한 후에는 원하는 모든 작업을 수행할 수 있습니다.  
5. `Workbook` 객체를 생성하고 OLE 데이터를 접근합니다.  
6. 원하는 `Worksheet`에 접근하여 데이터를 수정합니다.  
7. 업데이트된 `Workbook`을 스트림에 저장합니다.  
8. 스트림에서 OLE 객체 데이터를 변경합니다.  

아래 예제에서는 슬라이드에 삽입된 OLE 객체 프레임(Excel 차트 객체)에 접근하고 파일 데이터를 수정하여 차트 데이터를 업데이트합니다.

```csharp 
using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // 첫 번째 도형을 OLE 객체 프레임으로 가져옵니다.
    IOleObjectFrame oleFrame = slide.Shapes[0] as IOleObjectFrame;

    if (oleFrame != null)
    {
        using (MemoryStream oleStream = new MemoryStream(oleFrame.EmbeddedData.EmbeddedFileData))
        {
            // OLE 객체 데이터를 Workbook 객체로 읽습니다.
            Workbook workbook = new Workbook(oleStream);

            using (MemoryStream newOleStream = new MemoryStream())
            {
                // 워크북 데이터를 수정합니다.
                workbook.Worksheets[0].Cells[0, 4].PutValue("E");
                workbook.Worksheets[0].Cells[1, 4].PutValue(12);
                workbook.Worksheets[0].Cells[2, 4].PutValue(14);
                workbook.Worksheets[0].Cells[3, 4].PutValue(15);

                OoxmlSaveOptions fileOptions = new OoxmlSaveOptions(Aspose.Cells.SaveFormat.Xlsx);
                workbook.Save(newOleStream, fileOptions);

                // OLE 프레임 객체 데이터를 변경합니다.
                IOleEmbeddedDataInfo newData = new OleEmbeddedDataInfo(newOleStream.ToArray(), oleFrame.EmbeddedData.EmbeddedFileExtension);
                oleFrame.SetEmbeddedData(newData);
            }
        }
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **슬라이드에 다른 파일 유형 삽입**

Excel 차트 외에도 Aspose.Slides for .NET을 사용하면 슬라이드에 다른 유형의 파일을 삽입할 수 있습니다. 예를 들어 HTML, PDF 및 ZIP 파일을 객체로 삽입할 수 있습니다. 사용자가 삽입된 객체를 더블 클릭하면 해당 프로그램에서 자동으로 열리거나, 적절한 프로그램을 선택하라는 메시지가 표시됩니다.

다음 C# 코드는 HTML 및 ZIP을 슬라이드에 삽입하는 방법을 보여 줍니다:

```c#
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

## **삽입된 객체의 파일 유형 설정**

프레젠테이션 작업 중에는 오래된 OLE 객체를 새로운 것으로 교체하거나 지원되지 않는 OLE 객체를 지원되는 것으로 교체해야 할 수 있습니다. Aspose.Slides for .NET을 사용하면 삽입된 객체의 파일 유형을 설정하여 OLE 프레임 데이터 또는 확장자를 업데이트할 수 있습니다.

다음 C# 코드는 삽입된 OLE 객체의 파일 유형을 `zip`으로 설정하는 방법을 보여 줍니다:

```c#
using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IOleObjectFrame oleFrame = (IOleObjectFrame)slide.Shapes[0];

    string fileExtension = oleFrame.EmbeddedData.EmbeddedFileExtension;
    byte[] fileData = oleFrame.EmbeddedData.EmbeddedFileData;

    Console.WriteLine($"Current embedded file extension is: {fileExtension}");

    // 파일 유형을 ZIP으로 변경합니다.
    oleFrame.SetEmbeddedData(new OleEmbeddedDataInfo(fileData, "zip"));

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **삽입된 객체에 아이콘 이미지 및 제목 설정**

OLE 객체를 삽입하면 아이콘 이미지로 구성된 미리보기가 자동으로 추가됩니다. 이 미리보기는 사용자가 OLE 객체에 접근하거나 열기 전에 보는 내용입니다. 미리보기에 특정 이미지와 텍스트를 사용하려면 Aspose.Slides for .NET을 사용하여 아이콘 이미지와 제목을 설정하면 됩니다.

다음 C# 코드는 삽입된 객체에 아이콘 이미지와 제목을 설정하는 방법을 보여 줍니다:

```c#
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

## **OLE 객체 프레임이 크기 조정 및 위치 변경되는 것을 방지**

링크된 OLE 객체를 프레젠테이션 슬라이드에 추가한 후 PowerPoint에서 프레젠테이션을 열면 링크 업데이트를 요청하는 메시지가 표시될 수 있습니다. "Update Links" 버튼을 클릭하면 PowerPoint가 링크된 OLE 객체의 데이터를 업데이트하고 미리보기를 새로 고치기 때문에 OLE 객체 프레임의 크기와 위치가 변경될 수 있습니다. PowerPoint가 객체 데이터를 업데이트하라는 프롬프트를 표시하지 않도록 하려면 [IOleObjectFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/ioleobjectframe/) 인터페이스의 `UpdateAutomatic` 속성을 `false`로 설정하세요:

```cs
oleFrame.UpdateAutomatic = false;
```

## **삽입된 파일 추출**

Aspose.Slides for .NET을 사용하면 다음과 같이 슬라이드에 OLE 객체로 삽입된 파일을 추출할 수 있습니다:
1. 추출하려는 OLE 객체가 포함된 [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation) 클래스의 인스턴스를 생성합니다.  
2. 프레젠테이션의 모든 도형을 순회하면서 [OLEObjectFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/oleobjectframe) 형태에 접근합니다.  
3. OLE 객체 프레임에서 삽입된 파일 데이터를 읽어 디스크에 기록합니다.  

다음 C# 코드는 슬라이드에 OLE 객체로 삽입된 파일을 추출하는 방법을 보여 줍니다:

```c#
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

**Will the OLE content be rendered when exporting slides to PDF/images?**  
슬라이드에 보이는 것은 아이콘/대체 이미지(미리보기)만 렌더링됩니다. “실시간” OLE 콘텐츠는 렌더링 중에 실행되지 않습니다. 필요한 경우 내가 직접 만든 미리보기 이미지를 설정하여 PDF에서 기대한 모양을 보이게 할 수 있습니다.

**How can I lock an OLE object on a slide so users cannot move/edit it in PowerPoint?**  
도형 수준 잠금을 사용합니다. Aspose.Slides는 [shape-level locks](/slides/ko/net/applying-protection-to-presentation/)를 제공하며, 이는 암호화가 아니라 실수로 인한 편집 및 이동을 방지합니다.

**Why does a linked Excel object "jump" or change size when I open the presentation?**  
PowerPoint가 링크된 OLE의 미리보기를 새로 고칠 수 있습니다. 안정적인 표시를 위해서는 [Worksheet Resizing에 대한 실무 해결책](/slides/ko/net/working-solution-for-worksheet-resizing/)을 따르세요—프레임을 범위에 맞추거나 범위를 고정 프레임에 맞게 스케일링하고 적절한 대체 이미지를 설정합니다.

**Will relative paths for linked OLE objects be preserved in the PPTX format?**  
PPTX에서는 “상대 경로” 정보가 제공되지 않으며 전체 경로만 저장됩니다. 상대 경로는 오래된 PPT 형식에만 존재합니다. 이식성을 위해 절대 경로/접근 가능한 URI를 사용하거나 파일을 삽입하는 것이 좋습니다.