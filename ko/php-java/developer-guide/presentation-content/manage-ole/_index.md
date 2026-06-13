---
title: PHP로 프레젠테이션에서 OLE 관리
linktitle: OLE 관리
type: docs
weight: 40
url: /ko/php-java/manage-ole/
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
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java를 사용하여 PowerPoint 및 OpenDocument 파일에서 OLE 객체 관리를 최적화합니다. OLE 콘텐츠를 원활하게 삽입, 업데이트 및 내보냅니다."
---
## **소개**

{{% alert color="primary" %}} 

OLE(Object Linking & Embedding)는 하나의 애플리케이션에서 생성된 데이터와 개체를 연결 또는 포함을 통해 다른 애플리케이션에 배치할 수 있게 하는 Microsoft 기술입니다. 

{{% /alert %}} 

MS Excel에서 만든 차트를 생각해 보세요. 해당 차트를 PowerPoint 슬라이드에 삽입합니다. 이 Excel 차트는 OLE 객체로 간주됩니다. 

- OLE 객체는 아이콘 형태로 나타날 수 있습니다. 이 경우 아이콘을 두 번 클릭하면 차트가 연관된 애플리케이션(Excel)에서 열리거나, 객체를 열거나 편집할 애플리케이션을 선택하라는 메시지가 표시됩니다. 
- OLE 객체는 차트 내용과 같이 실제 내용을 표시할 수 있습니다. 이 경우 차트가 PowerPoint에서 활성화되고 차트 인터페이스가 로드되며, PowerPoint 내에서 차트 데이터를 수정할 수 있습니다. 

[Aspose.Slides for PHP via Java](https://products.aspose.com/slides/ko/php-java/)은 OLE 객체를 OLE 객체 프레임([OleObjectFrame](https://reference.aspose.com/slides/ko/php-java/aspose.slides/oleobjectframe/))으로 슬라이드에 삽입할 수 있게 합니다.

## **슬라이드에 OLE 객체 프레임 추가**

Microsoft Excel에서 차트를 이미 만든 상태이며 Aspose.Slides for PHP via Java를 사용해 OLE 객체 프레임으로 슬라이드에 삽입하려는 경우 다음과 같이 할 수 있습니다:

1. [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다. 
1. 인덱스를 통해 슬라이드 참조를 가져옵니다. 
1. Excel 파일을 바이트 배열로 읽어들입니다. 
1. 바이트 배열 및 OLE 객체에 관한 기타 정보를 포함하여 슬라이드에 [OleObjectFrame](https://reference.aspose.com/slides/ko/php-java/aspose.slides/oleobjectframe/)을 추가합니다. 
1. 수정된 프레젠테이션을 PPTX 파일로 저장합니다. 

아래 예제에서는 Aspose.Slides for PHP via Java를 사용해 Excel 파일의 차트를 OLE 객체 프레임으로 슬라이드에 추가했습니다.  
**Note** that the [OleEmbeddedDataInfo](https://reference.aspose.com/slides/ko/php-java/aspose.slides/oleembeddeddatainfo/) constructor takes an embeddable object extension as a second parameter. This extension allows PowerPoint to correctly interpret the file type and choose the right application to open this OLE object.

```php
$presentation = new Presentation();
$slideSize = $presentation->getSlideSize()->getSize();
$slide = $presentation->getSlides()->get_Item(0);

// Prepare data for the OLE object.
$fileData = file_get_contents("book.xlsx");
$dataInfo = new OleEmbeddedDataInfo($fileData, "xlsx");

// Add the OLE object frame to the slide.
$slide->getShapes()->addOleObjectFrame(0, 0, $slideSize->getWidth(), $slideSize->getHeight(), $dataInfo);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

### **연결된 OLE 객체 프레임 추가**

Aspose.Slides for PHP via Java는 데이터를 포함하지 않고 파일에 대한 링크만으로 [OleObjectFrame](https://reference.aspose.com/slides/ko/php-java/aspose.slides/oleobjectframe/)을 추가할 수 있게 합니다.

다음 PHP 코드는 연결된 Excel 파일을 사용해 슬라이드에 [OleObjectFrame](https://reference.aspose.com/slides/ko/php-java/aspose.slides/oleobjectframe/)을 추가하는 방법을 보여줍니다:

```php
$presentation = new Presentation();
$slide = $presentation->getSlides()->get_Item(0);

// 연결된 Excel 파일을 사용하여 OLE 객체 프레임을 추가합니다.
$slide->getShapes()->addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **OLE 객체 프레임 접근**

슬라이드에 OLE 객체가 이미 포함되어 있는 경우 다음과 같이 쉽게 찾거나 접근할 수 있습니다:

1. [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/) 클래스의 인스턴스를 생성하여 포함된 OLE 객체가 있는 프레젠테이션을 로드합니다. 
2. 인덱스를 사용해 슬라이드 참조를 얻습니다. 
3. [OleObjectFrame](https://reference.aspose.com/slides/ko/php-java/aspose.slides/oleobjectframe/) 형태에 접근합니다. 예제에서는 첫 슬라이드에 하나의 형태만 있는 기존 PPTX를 사용했습니다. 
4. OLE 객체 프레임에 접근한 후 원하는 모든 작업을 수행할 수 있습니다. 

아래 예제에서는 슬라이드에 삽입된 OLE 객체 프레임(Excel 차트 객체)과 해당 파일 데이터를 접근합니다.

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$shape = $slide->getShapes()->get_Item(0);

if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
    $oleFrame = $shape;
    
    // 삽입된 파일 데이터를 가져옵니다.
    $fileData = $oleFrame->getEmbeddedData()->getEmbeddedFileData();

    // 삽입된 파일의 확장자를 가져옵니다.
    $fileExtension = $oleFrame->getEmbeddedData()->getEmbeddedFileExtension();

    // ...
}
```

### **연결된 OLE 객체 프레임 속성 접근**

Aspose.Slides는 연결된 OLE 객체 프레임 속성에 접근할 수 있게 합니다.

다음 PHP 코드는 OLE 객체가 연결되어 있는지 확인하고 연결된 파일의 경로를 얻는 방법을 보여줍니다:

```php
$presentation = new Presentation("sample.ppt");
$slide = $presentation->getSlides()->get_Item(0);
$shape = $slide->getShapes()->get_Item(0);

if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
    $oleFrame = $shape;

    // OLE 객체가 연결되어 있는지 확인합니다.
    if (java_values($oleFrame->isObjectLink()) != 0) {
        // 연결된 파일의 전체 경로를 출력합니다.
        echo "OLE object frame is linked to: " . $oleFrame->getLinkPathLong() . PHP_EOL;

        // 존재한다면 연결된 파일의 상대 경로를 출력합니다.
        // 상대 경로는 PPT 프레젠테이션에만 포함될 수 있습니다.
        $relativePath = java_values($oleFrame->getLinkPathRelative());
        if (!is_null($relativePath) && $relativePath !== "") {
            echo "OLE object frame relative path: " . $oleFrame->getLinkPathRelative() . PHP_EOL;
        }
    }
}

$presentation->dispose();
```

## **OLE 객체 데이터 변경**

{{% alert color="primary" %}} 

이 섹션에서는 아래 코드 예제가 [Aspose.Cells for PHP via Java](/cells/php-java/)를 사용합니다.

{{% /alert %}}

슬라이드에 OLE 객체가 이미 포함되어 있는 경우 다음과 같이 해당 객체에 접근하고 데이터를 수정할 수 있습니다:

1. [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/) 클래스의 인스턴스를 생성하여 포함된 OLE 객체가 있는 프레젠테이션을 로드합니다. 
2. 인덱스를 통해 슬라이드 참조를 얻습니다. 
3. [OleObjectFrame](https://reference.aspose.com/slides/ko/php-java/aspose.slides/oleobjectframe/) 형태에 접근합니다. 예제에서는 첫 슬라이드에 하나의 형태만 있는 기존 PPTX를 사용했습니다. 
4. OLE 객체 프레임에 접근한 후 원하는 모든 작업을 수행할 수 있습니다. 
5. `Workbook` 객체를 생성하고 OLE 데이터를 접근합니다. 
6. 원하는 `Worksheet`에 접근하여 데이터를 수정합니다. 
7. 업데이트된 `Workbook`을 스트림에 저장합니다. 
8. 스트림에서 OLE 객체 데이터를 교체합니다. 

아래 예제에서는 슬라이드에 삽입된 OLE 객체 프레임(Excel 차트 객체)의 파일 데이터를 접근하고 차트 데이터를 업데이트하도록 수정합니다.

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$shape = $slide->getShapes()->get_Item(0);

if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
    $oleFrame = $shape;

    $oleStream = new ByteArrayInputStream($oleFrame->getEmbeddedData()->getEmbeddedFileData());

    // OLE 객체 데이터를 Workbook 객체로 읽어옵니다.
    $workbook = new Workbook($oleStream);

    $newOleStream = new Java("java.io.ByteArrayOutputStream");

    // 워크북 데이터를 수정합니다.
    $workbook->getWorksheets()->get(0)->getCells()->get(0, 4)->putValue("E");
    $workbook->getWorksheets()->get(0)->getCells()->get(1, 4)->putValue(12);
    $workbook->getWorksheets()->get(0)->getCells()->get(2, 4)->putValue(14);
    $workbook->getWorksheets()->get(0)->getCells()->get(3, 4)->putValue(15);

    $fileOptions = new OoxmlSaveOptions(SaveFormat::XLSX);
    $workbook->save($newOleStream, $fileOptions);

    // OLE 프레임 객체 데이터를 변경합니다.
    $newData = new OleEmbeddedDataInfo($newOleStream->toByteArray(), $oleFrame->getEmbeddedData()->getEmbeddedFileExtension());
    $oleFrame->setEmbeddedData($newData);

    $newOleStream->close();
    $oleStream->close();
}

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **다른 파일 형식을 슬라이드에 삽입**

Excel 차트 외에도 Aspose.Slides for PHP via Java를 사용하면 HTML, PDF, ZIP 등 다양한 파일 형식을 슬라이드에 객체로 삽입할 수 있습니다. 사용자가 삽입된 객체를 두 번 클릭하면 해당 프로그램이 자동으로 열리거나, 적절한 프로그램을 선택하라는 프롬프트가 표시됩니다.

다음 PHP 코드는 HTML과 ZIP을 슬라이드에 삽입하는 방법을 보여줍니다:

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);

$htmlData = file_get_contents("sample.html");
$htmlDataInfo = new OleEmbeddedDataInfo($htmlData, "html");
$htmlOleFrame = $slide->getShapes()->addOleObjectFrame(150, 120, 50, 50, $htmlDataInfo);
$htmlOleFrame->setObjectIcon(true);

$zipData = file_get_contents("sample.zip");
$zipDataInfo = new OleEmbeddedDataInfo($zipData, "zip");
$zipOleFrame = $slide->getShapes()->addOleObjectFrame(150, 220, 50, 50, $zipDataInfo);
$zipOleFrame->setObjectIcon(true);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **삽입된 객체의 파일 형식 설정**

프레젠테이션 작업 중 기존 OLE 객체를 새로운 것으로 교체하거나 지원되지 않는 OLE 객체를 지원되는 것으로 교체해야 할 때가 있습니다. Aspose.Slides for PHP via Java를 사용하면 삽입된 객체의 파일 형식을 설정하여 OLE 프레임 데이터 또는 확장자를 업데이트할 수 있습니다.

다음 PHP 코드는 삽입된 OLE 객체의 파일 형식을 `zip`으로 설정하는 방법을 보여줍니다:

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$oleFrame = $slide->getShapes()->get_Item(0);

$fileExtension = $oleFrame->getEmbeddedData()->getEmbeddedFileExtension();
$fileData = $oleFrame->getEmbeddedData()->getEmbeddedFileData();

echo "Current embedded file extension is: " . $fileExtension . PHP_EOL;

// 파일 형식을 ZIP으로 변경합니다.
$oleFrame->setEmbeddedData(new OleEmbeddedDataInfo($fileData, "zip"));

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **삽입된 객체의 아이콘 이미지 및 제목 설정**

OLE 객체를 삽입하면 아이콘 이미지가 자동으로 미리 보기 형태로 추가됩니다. 이 미리 보기는 사용자가 객체에 접근하거나 열기 전에 보게 되는 이미지입니다. 특정 이미지와 텍스트를 미리 보기 요소로 사용하고 싶다면 Aspose.Slides for PHP via Java를 이용해 아이콘 이미지와 제목을 설정할 수 있습니다.

다음 PHP 코드는 삽입된 객체의 아이콘 이미지와 제목을 설정하는 방법을 보여줍니다:

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$oleFrame = $slide->getShapes()->get_Item(0);

// 프레젠테이션 리소스에 이미지를 추가합니다.
$imageData = file_get_contents("image.png");
$oleImage = $presentation->getImages()->addImage($imageData);

// OLE 미리보기를 위한 제목과 이미지를 설정합니다.
$oleFrame->setSubstitutePictureTitle("My title");
$oleFrame->getSubstitutePictureFormat()->getPicture()->setImage($oleImage);
$oleFrame->setObjectIcon(true);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **OLE 객체 프레임이 크기 조정 및 위치 변경되는 것을 방지**

연결된 OLE 객체를 프레젠테이션 슬라이드에 추가한 뒤 PowerPoint에서 프레젠테이션을 열면 링크 업데이트 메시지가 표시될 수 있습니다. "Update Links" 버튼을 클릭하면 PowerPoint가 연결된 OLE 객체의 데이터를 업데이트하고 미리 보기를 새로 고치면서 OLE 객체 프레임의 크기와 위치가 변경될 수 있습니다. PowerPoint가 객체 데이터를 업데이트하도록 요청하는 것을 방지하려면 [OleObjectFrame](https://reference.aspose.com/slides/ko/php-java/aspose.slides/oleobjectframe/) 클래스의 `setUpdateAutomatic` 메서드를 `false`로 설정합니다:

```php
$oleFrame->setUpdateAutomatic(false);
```

## **삽입된 파일 추출**

Aspose.Slides for PHP via Java를 사용하면 슬라이드에 OLE 객체로 삽입된 파일을 다음과 같이 추출할 수 있습니다:

1. 추출하려는 OLE 객체가 포함된 [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다. 
2. 프레젠테이션의 모든 형태를 순회하면서 [OleObjectFrame](https://reference.aspose.com/slides/ko/php-java/aspose.slides/oleobjectframe/) 형태에 접근합니다. 
3. OLE 객체 프레임에서 삽입된 파일 데이터를 읽어 디스크에 저장합니다. 

다음 PHP 코드는 슬라이드에 삽입된 파일을 OLE 객체로 추출하는 방법을 보여줍니다:

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);

$shapeCount = java_values($slide->getShapes()->size());
for ($index = 0; $index < $shapeCount; $index++) {
    $shape = $slide->getShapes()->get_Item($index);

    if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
        $oleFrame = $shape;

        $fileData = $oleFrame->getEmbeddedData()->getEmbeddedFileData();
        $fileExtension = $oleFrame->getEmbeddedData()->getEmbeddedFileExtension();

        $filePath = "OLE_object_" . $index . $fileExtension;
        file_put_contents($filePath, $fileData);
    }
}

$presentation->dispose();
```

## **자주 묻는 질문**

**슬라이드를 PDF/이미지로 내보낼 때 OLE 콘텐츠가 렌더링됩니까?**

슬라이드에 보이는 아이콘/대체 이미지(미리 보기)만 렌더링됩니다. "실시간" OLE 콘텐츠는 렌더링 중에 실행되지 않습니다. 필요하다면 자체 미리 보기 이미지를 지정하여 내보낸 PDF에서 원하는 모양이 표시되도록 할 수 있습니다.

**PowerPoint에서 사용자가 OLE 객체를 이동하거나 편집하지 못하도록 슬라이드에 잠그려면 어떻게 해야 하나요?**

형태를 잠급니다: Aspose.Slides는 형태 수준의 잠금 기능을 제공합니다. 이것은 암호화가 아니지만 실수로 인한 편집 및 이동을 효과적으로 방지합니다.

**연결된 OLE 객체의 상대 경로가 PPTX 형식에 유지됩니까?**

PPTX에서는 "상대 경로" 정보가 제공되지 않으며 전체 경로만 저장됩니다. 상대 경로는 구형 PPT 형식에서만 지원됩니다. 이동성을 위해 신뢰할 수 있는 절대 경로/접근 가능한 URI 또는 삽입 방식을 사용하는 것이 좋습니다.