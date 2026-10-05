---
title: Java를 사용하여 프레젠테이션에서 OLE 관리
linktitle: OLE 관리
type: docs
weight: 40
url: /ko/java/manage-ole/
keywords:
- OLE 개체
- 객체 연결 및 포함
- OLE 추가
- OLE 삽입
- 개체 추가
- 개체 삽입
- 파일 추가
- 파일 삽입
- 링크된 개체
- 링크된 파일
- OLE 변경
- OLE 아이콘
- OLE 제목
- OLE 추출
- 개체 추출
- 파일 추출
- PowerPoint
- 프레젠테이션
- Java
- Aspose.Slides
description: "Aspose.Slides for Java를 사용하여 PowerPoint 및 OpenDocument 파일에서 OLE 개체 관리를 최적화합니다. OLE 콘텐츠를 원활하게 삽입, 업데이트 및 내보낼 수 있습니다."
---
## **소개**

{{% alert color="info" title="Note" %}}

OLE (Object Linking & Embedding)은 데이터를 한 응용 프로그램에서 생성된 개체를 다른 응용 프로그램에 연결 또는 포함하여 배치할 수 있게 해주는 Microsoft 기술입니다. 

{{% /alert %}} 

MS Excel에서 만든 차트를 생각해 보십시오. 해당 차트는 PowerPoint 슬라이드에 배치됩니다. 그 Excel 차트는 OLE 개체로 간주됩니다. 

- OLE 개체는 아이콘으로 표시될 수 있습니다. 이 경우 아이콘을 두 번 클릭하면 차트가 연결된 응용 프로그램(Excel)에서 열리거나, 개체를 열거나 편집할 응용 프로그램을 선택하라는 메시지가 표시됩니다.
- OLE 개체는 차트 내용과 같이 실제 내용을 표시할 수 있습니다. 이 경우 차트가 PowerPoint에서 활성화되고 차트 인터페이스가 로드되어 PowerPoint 내에서 차트 데이터를 수정할 수 있습니다.

[Aspose.Slides for Java](https://products.aspose.com/slides/java/)은 OLE 개체를 OLE 개체 프레임([OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame))으로 슬라이드에 삽입할 수 있게 합니다.

## **슬라이드에 OLE 개체 프레임 추가**

Microsoft Excel에서 이미 차트를 만든 상태이며 Aspose.Slides for Java를 사용하여 해당 차트를 OLE 개체 프레임으로 슬라이드에 포함하려는 경우 다음과 같이 수행할 수 있습니다:

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.
1. 인덱스를 사용하여 슬라이드의 참조를 가져옵니다.
1. Excel 파일을 바이트 배열로 읽습니다.
1. OLE 개체에 대한 바이트 배열 및 기타 정보를 포함하여 슬라이드에 [OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame)을 추가합니다.
1. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

아래 예제에서는 Aspose.Slides for Java를 사용하여 Excel 파일의 차트를 OLE 개체 프레임으로 슬라이드에 추가했습니다.
**참고** [OleEmbeddedDataInfo](https://reference.aspose.com/slides/java/com.aspose.slides/OleEmbeddedDataInfo) 생성자는 두 번째 매개변수로 삽입 가능한 개체 확장자를 받습니다. 이 확장자는 PowerPoint가 파일 유형을 올바르게 해석하고 해당 OLE 개체를 열 올바른 응용 프로그램을 선택하도록 합니다.

``` java 
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
Dimension2D slideSize = presentation.getSlideSize().getSize();
ISlide slide = presentation.getSlides().get_Item(0);

// OLE 개체를 위한 데이터를 준비합니다.
byte[] fileData = Files.readAllBytes(Paths.get("book.xlsx"));
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(fileData, "xlsx");

// 슬라이드에 OLE 개체 프레임을 추가합니다.
slide.getShapes().addOleObjectFrame(0, 0, (float)slideSize.getWidth(), (float)slideSize.getHeight(), dataInfo);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

### **연결된 OLE 개체 프레임 추가**

Aspose.Slides for Java는 데이터를 삽입하지 않고 파일에 대한 링크만으로 [OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame)을 추가할 수 있게 합니다.

다음 Java 코드는 연결된 Excel 파일을 사용하여 [OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame)을 슬라이드에 추가하는 방법을 보여 줍니다:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// 연결된 Excel 파일이 있는 OLE 개체 프레임을 추가합니다.
slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **OLE 개체 프레임 액세스**

슬라이드에 OLE 개체가 이미 삽입되어 있는 경우 다음과 같이 쉽게 찾거나 접근할 수 있습니다:

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 클래스의 인스턴스를 생성하여 OLE 개체가 포함된 프레젠테이션을 로드합니다.
2. 인덱스를 사용하여 슬라이드의 참조를 가져옵니다.
3. [OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame) 형태에 접근합니다. 예제에서는 첫 번째 슬라이드에 하나의 형태만 있는 이전에 만든 PPTX를 사용했습니다. 그런 다음 해당 객체를 [IOleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IOleObjectFrame)으로 *형변환*했습니다. 이것이 접근하려는 OLE 개체 프레임이었습니다.
4. OLE 개체 프레임에 접근한 후에는 원하는 모든 작업을 수행할 수 있습니다.

아래 예제에서는 슬라이드에 삽입된 Excel 차트 개체와 해당 파일 데이터에 접근합니다.

``` java 
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;
    
    // 삽입된 파일 데이터를 가져옵니다.
    byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

    // 삽입된 파일의 확장자를 가져옵니다.
    String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

    // ...
}
```

### **연결된 OLE 개체 프레임 속성 액세스**

Aspose.Slides는 연결된 OLE 개체 프레임 속성에 접근할 수 있게 합니다.

다음 Java 코드는 OLE 개체가 연결되어 있는지 확인하고 연결된 파일의 경로를 얻는 방법을 보여 줍니다:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.ppt");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

    // OLE 개체가 연결되어 있는지 확인합니다.
    if (oleFrame.isObjectLink()) {
        // 연결된 파일의 전체 경로를 출력합니다.
        System.out.println("OLE object frame is linked to: " + oleFrame.getLinkPathLong());

        // 존재하는 경우 연결된 파일의 상대 경로를 출력합니다.
        // PPT 프레젠테이션에서만 상대 경로를 포함할 수 있습니다.
        if (oleFrame.getLinkPathRelative() != null && !oleFrame.getLinkPathRelative().isEmpty()) {
            System.out.println("OLE object frame relative path: " + oleFrame.getLinkPathRelative());
        }
    }
}

presentation.dispose();
```

## **OLE 개체 데이터 변경**

{{% alert color="info" title="Note" %}}

이 섹션에서는 아래 코드 예제가 [Aspose.Cells for Java](https://docs.aspose.com/cells/java/)를 사용합니다.

{{% /alert %}}

OLE 개체가 이미 슬라이드에 삽입되어 있는 경우 다음과 같이 해당 개체에 접근하고 데이터를 수정할 수 있습니다:

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 클래스의 인스턴스를 생성하여 OLE 개체가 포함된 프레젠테이션을 로드합니다.
2. 인덱스를 사용하여 슬라이드의 참조를 가져옵니다. 
3. OLE 개체 프레임 형태에 접근합니다. 예제에서는 첫 번째 슬라이드에 하나의 형태만 있는 이전에 만든 PPTX를 사용했습니다. 그런 다음 해당 객체를 [IOleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IOleObjectFrame)으로 *형변환*했습니다. 이것이 접근하려는 OLE 개체 프레임이었습니다.
4. OLE 개체 프레임에 접근한 후에는 원하는 모든 작업을 수행할 수 있습니다.
5. `Workbook` 객체를 생성하고 OLE 데이터를 접근합니다.
6. 원하는 `Worksheet`에 접근하여 데이터를 수정합니다.
7. 업데이트된 `Workbook`을 스트림에 저장합니다.
8. 스트림을 사용하여 OLE 개체 데이터를 변경합니다.

아래 예제에서는 슬라이드에 삽입된 Excel 차트 개체에 접근하고, 파일 데이터를 수정하여 차트 데이터를 업데이트합니다.

``` java 
import com.aspose.slides.*;
import com.aspose.cells.Workbook;
import com.aspose.cells.OoxmlSaveOptions;
import java.io.ByteArrayInputStream;
import java.io.ByteArrayOutputStream;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

    ByteArrayInputStream oleStream = new ByteArrayInputStream(oleFrame.getEmbeddedData().getEmbeddedFileData());

    // OLE 개체 데이터를 Workbook 객체로 읽습니다.
    Workbook workbook = new Workbook(oleStream);

    ByteArrayOutputStream newOleStream = new ByteArrayOutputStream();

    // Workbook 데이터를 수정합니다.
    workbook.getWorksheets().get(0).getCells().get(0, 4).putValue("E");
    workbook.getWorksheets().get(0).getCells().get(1, 4).putValue(12);
    workbook.getWorksheets().get(0).getCells().get(2, 4).putValue(14);
    workbook.getWorksheets().get(0).getCells().get(3, 4).putValue(15);

    OoxmlSaveOptions fileOptions = new OoxmlSaveOptions(com.aspose.cells.SaveFormat.XLSX);
    workbook.save(newOleStream, fileOptions);

    // OLE 프레임 개체 데이터를 변경합니다.
    IOleEmbeddedDataInfo newData = new OleEmbeddedDataInfo(newOleStream.toByteArray(), oleFrame.getEmbeddedData().getEmbeddedFileExtension());
    oleFrame.setEmbeddedData(newData);
}

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **슬라이드에 다른 파일 유형 삽입**

Excel 차트 외에도 Aspose.Slides for Java를 사용하면 HTML, PDF, ZIP 파일 등 다양한 유형의 파일을 슬라이드에 객체로 삽입할 수 있습니다. 사용자가 삽입된 객체를 두 번 클릭하면 해당 프로그램이 자동으로 열리거나, 적절한 프로그램을 선택하라는 프롬프트가 표시됩니다.

다음 Java 코드는 HTML과 ZIP을 슬라이드에 삽입하는 방법을 보여 줍니다:

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

byte[] htmlData = Files.readAllBytes(Paths.get("sample.html"));
IOleEmbeddedDataInfo htmlDataInfo = new OleEmbeddedDataInfo(htmlData, "html");
IOleObjectFrame htmlOleFrame = slide.getShapes().addOleObjectFrame(150, 120, 50, 50, htmlDataInfo);
htmlOleFrame.setObjectIcon(true);

byte[] zipData = Files.readAllBytes(Paths.get("sample.zip"));
IOleEmbeddedDataInfo zipDataInfo = new OleEmbeddedDataInfo(zipData, "zip");
IOleObjectFrame zipOleFrame = slide.getShapes().addOleObjectFrame(150, 220, 50, 50, zipDataInfo);
zipOleFrame.setObjectIcon(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **삽입된 개체의 파일 유형 설정**

프레젠테이션 작업 중에 오래된 OLE 개체를 새 개체로 교체하거나 지원되지 않는 OLE 개체를 지원되는 개체로 교체해야 할 수 있습니다. Aspose.Slides for Java는 삽입된 개체의 파일 유형을 설정하여 OLE 프레임 데이터나 확장자를 업데이트할 수 있게 합니다.

다음 Java 코드는 삽입된 OLE 개체의 파일 유형을 `zip`으로 설정하는 방법을 보여 줍니다:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();
byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

System.out.println("Current embedded file extension is: " + fileExtension);

// Change the file type to ZIP.
oleFrame.setEmbeddedData(new OleEmbeddedDataInfo(fileData, "zip"));

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **삽입된 개체의 아이콘 이미지 및 제목 설정**

OLE 개체를 삽입하면 아이콘 이미지로 구성된 미리 보기가 자동으로 추가됩니다. 이 미리 보기는 사용자가 OLE 개체에 접근하거나 열기 전에 보는 모습입니다. 미리 보기에서 특정 이미지와 텍스트를 사용하려면 Aspose.Slides for Java를 이용해 아이콘 이미지와 제목을 설정할 수 있습니다.

다음 Java 코드는 삽입된 개체에 아이콘 이미지와 제목을 설정하는 방법을 보여 줍니다:

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

// 프레젠테이션 리소스에 이미지를 추가합니다.
byte[] imageData = Files.readAllBytes(Paths.get("image.png"));
IPPImage oleImage = presentation.getImages().addImage(imageData);

// Set a title and the image for the OLE preview.
oleFrame.setSubstitutePictureTitle("My title");
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **OLE 개체 프레임이 크기 조정 및 위치 변경되는 것을 방지**

연결된 OLE 개체를 프레젠테이션 슬라이드에 추가한 뒤 PowerPoint에서 프레젠테이션을 열면 링크 업데이트를 요청하는 메시지가 표시될 수 있습니다. "Update Links" 버튼을 클릭하면 PowerPoint가 연결된 OLE 개체의 데이터를 업데이트하고 미리 보기를 새로 고침하기 때문에 OLE 개체 프레임의 크기와 위치가 변경될 수 있습니다. PowerPoint가 개체 데이터 업데이트를 묻지 않도록 하려면 [IOleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ioleobjectframe/) 인터페이스의 [setUpdateAutomatic](https://reference.aspose.com/slides/java/com.aspose.slides/ioleobjectframe/#setUpdateAutomatic-boolean-) 메서드를 `false`로 호출합니다:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

oleFrame.setUpdateAutomatic(false);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **삽입된 파일 추출**

Aspose.Slides for Java를 사용하면 슬라이드에 OLE 개체로 삽입된 파일을 다음과 같이 추출할 수 있습니다:

1. 추출하려는 OLE 개체가 포함된 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.
2. 프레젠테이션의 모든 형태를 순회하면서 [OLEObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/oleobjectframe) 형태에 접근합니다.
3. OLE 개체 프레임에서 삽입된 파일 데이터를 접근하고 디스크에 기록합니다.

다음 Java 코드는 슬라이드에 OLE 개체로 삽입된 파일을 추출하는 방법을 보여 줍니다:

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);

for (int index = 0; index < slide.getShapes().size(); index++) {
    IShape shape = slide.getShapes().get_Item(index);

    if (shape instanceof IOleObjectFrame) {
        IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

        byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();
        String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

        Path filePath = Paths.get("OLE_object_" + index + fileExtension);
        Files.write(filePath, fileData);
    }
}

presentation.dispose();
```

## **FAQ**

**슬라이드를 PDF/이미지로 내보낼 때 OLE 내용이 렌더링됩니까?**

슬라이드에 보이는 것은 아이콘/대체 이미지(미리 보기)이며, 실제 OLE 콘텐츠는 렌더링 중에 실행되지 않습니다. 필요하다면 자체 미리 보기 이미지를 설정하여 내보낸 PDF에서 기대한 모습을 보이게 할 수 있습니다.

삽입된 파일을 PDF 첨부 파일로도 보존하려면 `true`와 함께 [setIncludeOleData](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setIncludeOleData-boolean-)를 호출하십시오. 이 옵션은 기본적으로 비활성화되어 있습니다. 예제와 첨부 파일 확인 방법은 [Preserve Embedded OLE Files as PDF Attachments](/slides/ko/java/convert-powerpoint-to-pdf/#preserve-embedded-ole-files-as-pdf-attachments)를 참고하십시오.

**PowerPoint에서 사용자가 OLE 개체를 이동/편집하지 못하도록 슬라이드에 고정하려면 어떻게 해야 하나요?**

형태를 잠그세요: Aspose.Slides는 [shape-level locks](/slides/ko/java/applying-protection-to-presentation/)를 제공합니다. 이는 암호화는 아니지만 실수로 인한 편집 및 이동을 효과적으로 방지합니다.

**연결된 Excel 개체가 프레젠테이션을 열 때 “점프”하거나 크기가 변하는 이유는 무엇인가요?**

PowerPoint가 연결된 OLE의 미리 보기를 새로 고칠 수 있습니다. 안정적인 표시를 위해서는 [Working Solution for Worksheet Resizing](/slides/ko/java/working-solution-for-worksheet-resizing/) 권장 사항을 따르세요—프레임을 범위에 맞추거나 범위를 고정 프레임에 맞게 스케일링하고 적절한 대체 이미지를 설정합니다.

**PPTX 형식에서 연결된 OLE 개체의 상대 경로가 보존됩니까?**

PPTX에서는 “relative path” 정보가 제공되지 않으며 전체 경로만 포함됩니다. 상대 경로는 오래된 PPT 형식에서만 찾아볼 수 있습니다. 이동성을 위해서는 신뢰할 수 있는 절대 경로/접근 가능한 URI 또는 삽입 방식을 사용하는 것이 좋습니다.