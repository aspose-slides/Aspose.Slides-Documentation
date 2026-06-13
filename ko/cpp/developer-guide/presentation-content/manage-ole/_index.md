---
title: C++를 사용한 프레젠테이션에서 OLE 관리
linktitle: OLE 관리
type: docs
weight: 40
url: /ko/cpp/manage-ole/
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
- C++
- Aspose.Slides
description: "Aspose.Slides for C++를 사용하여 PowerPoint 및 OpenDocument 파일에서 OLE 객체 관리를 최적화합니다. OLE 콘텐츠를 원활하게 삽입, 업데이트 및 내보냅니다."
---
## **소개**

{{% alert title="Info" color="info" %}}

OLE(Object Linking & Embedding)는 하나의 응용 프로그램에서 만든 데이터와 객체를 연결 또는 포함을 통해 다른 응용 프로그램에 배치할 수 있게 하는 Microsoft 기술입니다. 

{{% /alert %}} 

MS Excel에서 만든 차트를 생각해 보세요. 이 차트가 PowerPoint 슬라이드에 배치됩니다. 해당 Excel 차트는 OLE 개체로 간주됩니다. 

- OLE 개체는 아이콘으로 표시될 수 있습니다. 이 경우 아이콘을 더블 클릭하면 차트가 연결된 응용 프로그램(Excel)에서 열리거나, 개체를 열거나 편집할 응용 프로그램을 선택하라는 메시지가 표시됩니다. 
- OLE 개체는 차트 내용과 같이 실제 내용을 표시할 수 있습니다. 이 경우 차트가 PowerPoint에서 활성화되고 차트 인터페이스가 로드되어 PowerPoint 내에서 차트 데이터를 수정할 수 있습니다. 

[Aspose.Slides for C++](https://products.aspose.com/slides/ko/cpp/)를 사용하면 OLE 개체를 OLE 개체 프레임([OleObjectFrame](https://reference.aspose.com/slides/ko/cpp/aspose.slides/oleobjectframe/))으로 슬라이드에 삽입할 수 있습니다.

## **OLE 개체 프레임을 슬라이드에 추가하기**

Microsoft Excel에서 차트를 이미 만든 상태이고 Aspose.Slides for C++를 사용하여 해당 차트를 OLE 개체 프레임으로 슬라이드에 포함하려는 경우 다음과 같이 수행할 수 있습니다.

1. [Presentation](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.presentation) 클래스의 인스턴스를 생성합니다.  
2. 인덱스를 사용하여 슬라이드 참조를 가져옵니다.  
3. Excel 파일을 바이트 배열로 읽어옵니다.  
4. 바이트 배열 및 OLE 개체에 대한 기타 정보를 포함하여 슬라이드에 [OleObjectFrame](https://reference.aspose.com/slides/ko/cpp/aspose.slides/oleobjectframe/)을 추가합니다.  
5. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.  

아래 예제에서는 Excel 파일의 차트를 Aspose.Slides for C++를 사용해 [OleObjectFrame](https://reference.aspose.com/slides/ko/cpp/aspose.slides/oleobjectframe/)으로 슬라이드에 추가했습니다.  
**참고**: [OleEmbeddedDataInfo](https://reference.aspose.com/slides/ko/cpp/aspose.slides.dom.ole/oleembeddeddatainfo/) 생성자는 두 번째 매개변수로 포함 가능한 개체 확장자를 받습니다. 이 확장자는 PowerPoint가 파일 형식을 올바르게 해석하고 해당 OLE 개체를 열 적절한 응용 프로그램을 선택하도록 합니다.

``` cpp
auto presentation = MakeObject<Presentation>();
auto slideSize = presentation->get_SlideSize()->get_Size();
auto slide = presentation->get_Slide(0);

// OLE 객체를 위한 데이터를 준비합니다.
auto fileData = File::ReadAllBytes(u"book.xlsx");
auto dataInfo = MakeObject<OleEmbeddedDataInfo>(fileData, u"xlsx");

// OLE 객체 프레임을 슬라이드에 추가합니다.
slide->get_Shapes()->AddOleObjectFrame(0, 0, slideSize.get_Width(), slideSize.get_Height(), dataInfo);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **연결된 OLE 개체 프레임 추가**

Aspose.Slides for C++를 사용하면 데이터를 포함하지 않고 파일에 대한 링크만으로 [OleObjectFrame](https://reference.aspose.com/slides/ko/cpp/aspose.slides/oleobjectframe/)을 추가할 수 있습니다.

다음 C++ 코드는 연결된 Excel 파일을 사용해 슬라이드에 [OleObjectFrame](https://reference.aspose.com/slides/ko/cpp/aspose.slides/oleobjectframe/)을 추가하는 방법을 보여줍니다:

```cpp
auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

// 연결된 Excel 파일로 OLE 객체 프레임을 추가합니다.
slide->get_Shapes()->AddOleObjectFrame(20, 20, 200, 150, u"Excel.Sheet.12", u"book.xlsx");

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **OLE 개체 프레임 액세스**

슬라이드에 OLE 개체가 이미 포함되어 있는 경우 다음과 같이 쉽게 찾거나 액세스할 수 있습니다.

1. [Presentation](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.presentation) 클래스 인스턴스를 생성하여 포함된 OLE 개체가 있는 프레젠테이션을 로드합니다.  
2. 인덱스를 사용하여 슬라이드 참조를 가져옵니다.  
3. [OleObjectFrame](https://reference.aspose.com/slides/ko/cpp/aspose.slides/oleobjectframe/) 셰이프에 액세스합니다.  
   예제에서는 첫 번째 슬라이드에 하나의 셰이프만 있는 이전에 만든 PPTX를 사용했습니다. 그런 다음 해당 개체를 [IOleObjectFrame](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ioleobjectframe/)으로 *캐스팅*했습니다. 이 개체가 접근하려는 OLE 개체 프레임이었습니다.  
4. OLE 개체 프레임에 접근하면 원하는 모든 작업을 수행할 수 있습니다.  

아래 예제에서는 OLE 개체 프레임(슬라이드에 포함된 Excel 차트 개체)과 해당 파일 데이터를 액세스합니다.

``` cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shape(0);

if (ObjectExt::Is<IOleObjectFrame>(shape))
{ 
    auto oleFrame = ExplicitCast<IOleObjectFrame>(shape);

    // 내장 파일 데이터를 가져옵니다.
    auto fileData = oleFrame->get_EmbeddedData()->get_EmbeddedFileData();

    // 내장 파일의 확장자를 가져옵니다.
    auto fileExtension = oleFrame->get_EmbeddedData()->get_EmbeddedFileExtension();

    // ...
}
```

### **연결된 OLE 개체 프레임 속성 액세스**

Aspose.Slides를 사용하면 연결된 OLE 개체 프레임 속성에 접근할 수 있습니다.

다음 C++ 코드는 OLE 개체가 연결되어 있는지 확인하고 연결된 파일의 경로를 얻는 방법을 보여줍니다:

```cpp
auto presentation = MakeObject<Presentation>(u"sample.ppt");
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shape(0);

if (ObjectExt::Is<IOleObjectFrame>(shape))
{
    auto oleFrame = ExplicitCast<IOleObjectFrame>(shape);

    // OLE 객체가 연결되어 있는지 확인합니다.
    if (oleFrame->get_IsObjectLink())
    {
        // 연결된 파일의 전체 경로를 출력합니다.
        std::wcout << L"OLE object frame is linked to: " << oleFrame->get_LinkPathLong() << std::endl;

        // 존재한다면 연결된 파일의 상대 경로를 출력합니다.
        // 상대 경로는 PPT 프레젠테이션에만 포함될 수 있습니다.
        if (!String::IsNullOrEmpty(oleFrame->get_LinkPathRelative()))
        {
            std::wcout << L"OLE object frame relative path: " << oleFrame->get_LinkPathRelative() << std::endl;
        }
    }
}
```

## **OLE 개체 데이터 변경**

{{% alert color="primary" %}} 

이 섹션에서는 아래 코드 예제가 [Aspose.Cells for C++](/cells/cpp/)를 사용합니다.

{{% /alert %}}

슬라이드에 OLE 개체가 이미 포함되어 있는 경우 다음과 같이 해당 개체에 접근하여 데이터를 수정할 수 있습니다.

1. [Presentation](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.presentation) 클래스 인스턴스를 생성하여 포함된 OLE 개체가 있는 프레젠테이션을 로드합니다.  
2. 인덱스를 사용하여 슬라이드 참조를 가져옵니다.  
3. [OLEObjectFrame](https://reference.aspose.com/slides/ko/cpp/aspose.slides/oleobjectframe/) 셰이프에 액세스합니다.  
   예제에서는 첫 번째 슬라이드에 하나의 셰이프만 있는 이전에 만든 PPTX를 사용했습니다. 그런 다음 해당 개체를 [IOleObjectFrame](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ioleobjectframe/)으로 *캐스팅*했습니다. 이 개체가 접근하려는 OLE 개체 프레임이었습니다.  
4. OLE 개체 프레임에 접근하면 원하는 모든 작업을 수행할 수 있습니다.  
5. `Workbook` 개체를 생성하고 OLE 데이터를 액세스합니다.  
6. 원하는 `Worksheet`에 접근하여 데이터를 수정합니다.  
7. 업데이트된 `Workbook`을 스트림에 저장합니다.  
8. 스트림을 사용해 OLE 개체 데이터를 변경합니다.  

아래 예제에서는 OLE 개체 프레임(슬라이드에 포함된 Excel 차트 개체)에 접근하고 파일 데이터를 수정하여 차트 데이터를 업데이트합니다.

``` cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

// 첫 번째 셰이프를 OLE 객체 프레임으로 가져옵니다.
auto oleFrame = AsCast<IOleObjectFrame>(slide->get_Shape(0));

if (oleFrame != nullptr)
{
    auto oleStream = MakeObject<MemoryStream>(oleFrame->get_EmbeddedData()->get_EmbeddedFileData());

    // OLE 객체 데이터를 Workbook 객체로 읽어옵니다.
    auto oleArray = oleStream->ToArray();
    std::vector<uint8_t> workbookData(oleArray->data().begin(), oleArray->data().end());
    Aspose::Cells::Workbook workbook(Aspose::Cells::Vector<uint8_t>(workbookData.data(), workbookData.size()));

    // 워크북 데이터를 수정합니다.
    auto worksheet = workbook.GetWorksheets().Get(0);
    worksheet.GetCells().Get(0, 4).PutValue(Aspose::Cells::U16String("E"));
    worksheet.GetCells().Get(1, 4).PutValue(12);
    worksheet.GetCells().Get(2, 4).PutValue(14);
    worksheet.GetCells().Get(3, 4).PutValue(15);

    Aspose::Cells::OoxmlSaveOptions fileOptions(Aspose::Cells::SaveFormat::Xlsx);
    auto newWorkbookData = workbook.Save(fileOptions);

    auto newOleStream = MakeObject<MemoryStream>();
    newOleStream->Write(
        MakeArray<uint8_t>(std::vector<uint8_t>(newWorkbookData.GetData(), newWorkbookData.GetData() + newWorkbookData.GetLength())),
        0, newWorkbookData.GetLength());

    // OLE 프레임 객체 데이터를 변경합니다.
    auto newData = MakeObject<OleEmbeddedDataInfo>(newOleStream->ToArray(), oleFrame->get_EmbeddedData()->get_EmbeddedFileExtension());
    oleFrame->SetEmbeddedData(newData);
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
```

## **슬라이드에 다른 파일 형식 삽입**

Excel 차트 외에도 Aspose.Slides for C++를 사용하면 HTML, PDF, ZIP 파일 등을 개체로 삽입해 슬라이드에 포함시킬 수 있습니다. 사용자가 삽입된 개체를 더블 클릭하면 해당 프로그램에서 자동으로 열리거나, 적절한 프로그램을 선택하라는 메시지가 표시됩니다.

다음 C++ 코드는 HTML과 ZIP 파일을 슬라이드에 삽입하는 방법을 보여줍니다:

``` cpp
auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto htmlData = File::ReadAllBytes(u"sample.html");
auto htmlDataInfo = MakeObject<OleEmbeddedDataInfo>(htmlData, u"html");
auto htmlOleFrame = slide->get_Shapes()->AddOleObjectFrame(150, 120, 50, 50, htmlDataInfo);
htmlOleFrame->set_IsObjectIcon(true);

auto zipData = File::ReadAllBytes(u"sample.zip");
auto zipDataInfo = MakeObject<OleEmbeddedDataInfo>(zipData, u"zip");
auto zipOleFrame = slide->get_Shapes()->AddOleObjectFrame(150, 220, 50, 50, zipDataInfo);
zipOleFrame->set_IsObjectIcon(true);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **삽입된 개체의 파일 형식 설정**

프레젠테이션 작업 중에 이전 OLE 개체를 새로운 개체로 교체하거나 지원되지 않는 OLE 개체를 지원되는 개체로 교체해야 할 수 있습니다. Aspose.Slides for C++를 사용하면 삽입된 개체의 파일 형식을 설정하여 OLE 프레임 데이터 또는 확장자를 업데이트할 수 있습니다.

다음 C++ 코드는 삽입된 OLE 개체의 파일 형식을 `zip`으로 설정하는 방법을 보여줍니다:

``` cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
auto oleFrame = ExplicitCast<IOleObjectFrame>(slide->get_Shape(0));

auto fileExtension = oleFrame->get_EmbeddedData()->get_EmbeddedFileExtension();
auto fileData = oleFrame->get_EmbeddedData()->get_EmbeddedFileData();

std::wcout << L"Current embedded file extension is: " << fileExtension << std::endl;

// 파일 형식을 ZIP으로 변경합니다.
oleFrame->SetEmbeddedData(MakeObject<OleEmbeddedDataInfo>(fileData, u"zip"));

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **삽입된 개체의 아이콘 이미지 및 제목 설정**

OLE 개체를 삽입하면 미리보기 아이콘 이미지가 자동으로 추가됩니다. 이 미리보기는 사용자가 OLE 개체에 접근하거나 열기 전에 보게 되는 내용입니다. 특정 이미지와 텍스트를 미리보기 요소로 사용하려면 Aspose.Slides for C++를 사용해 아이콘 이미지와 제목을 설정할 수 있습니다.

다음 C++ 코드는 삽입된 개체에 대해 아이콘 이미지와 제목을 설정하는 방법을 보여줍니다: 

``` cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
auto oleFrame = ExplicitCast<IOleObjectFrame>(slide->get_Shape(0));

// 프레젠테이션 리소스에 이미지를 추가합니다.
auto imageData = File::ReadAllBytes(u"image.png");
auto oleImage = presentation->get_Images()->AddImage(imageData);

// Set a title and the image for the OLE preview.
oleFrame->set_SubstitutePictureTitle(u"My title");
oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(oleImage);
oleFrame->set_IsObjectIcon(true);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **OLE 개체 프레임의 크기 조정 및 위치 변경 방지**

연결된 OLE 개체를 프레젠테이션 슬라이드에 추가한 후 PowerPoint에서 프레젠테이션을 열면 링크를 업데이트하라는 메시지가 표시될 수 있습니다. "링크 업데이트" 버튼을 클릭하면 PowerPoint가 연결된 OLE 개체의 데이터를 업데이트하고 미리보기를 새로 고치면서 OLE 개체 프레임의 크기와 위치가 변경될 수 있습니다. PowerPoint가 개체 데이터를 업데이트하도록 묻는 메시지를 방지하려면 [IOleObjectFrame](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ioleobjectframe/) 인터페이스의 `set_UpdateAutomatic` 메서드를 `false`로 설정합니다:

```cpp
oleFrame->set_UpdateAutomatic(false);
```

## **삽입된 파일 추출**

Aspose.Slides for C++를 사용하면 슬라이드에 OLE 개체로 삽입된 파일을 다음과 같이 추출할 수 있습니다.

1. 추출하려는 OLE 개체가 포함된 [Presentation](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.presentation) 클래스 인스턴스를 생성합니다.  
2. 프레젠테이션의 모든 셰이프를 순회하며 [OLEObjectFrame](https://reference.aspose.com/slides/ko/cpp/aspose.slides/oleobjectframe/) 셰이프에 접근합니다.  
3. OLE 개체 프레임에서 삽입된 파일 데이터를 가져와 디스크에 기록합니다.  

다음 C++ 코드는 슬라이드에 OLE 개체로 삽입된 파일을 추출하는 방법을 보여줍니다:

``` cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

for (int index = 0; index < slide->get_Shapes()->get_Count(); index++)
{
    auto shape = slide->get_Shape(index);

    if (ObjectExt::Is<IOleObjectFrame>(shape))
    { 
        auto oleFrame = ExplicitCast<IOleObjectFrame>(shape);

        auto fileData = oleFrame->get_EmbeddedData()->get_EmbeddedFileData();
        auto fileExtension = oleFrame->get_EmbeddedData()->get_EmbeddedFileExtension();

        auto fileName = String::Format(u"OLE_object_{0}{1}", index, fileExtension);
        File::WriteAllBytes(fileName, fileData);
    }
}

presentation->Dispose();
```

## **FAQ**

**슬라이드를 PDF/이미지로 내보낼 때 OLE 콘텐츠가 렌더링됩니까?**

슬라이드에 표시되는 부분, 즉 아이콘/대체 이미지(미리보기)만 렌더링됩니다. "실시간" OLE 콘텐츠는 렌더링 중에 실행되지 않습니다. 필요하다면 자체 미리보기 이미지를 설정해 내보낸 PDF에서 기대한 모양을 보이게 할 수 있습니다.

**PowerPoint에서 사용자가 OLE 개체를 이동하거나 편집하지 못하도록 슬라이드에 잠그려면 어떻게 해야 하나요?**

셰이프를 잠그세요: Aspose.Slides는 [shape-level locks](/slides/ko/cpp/applying-protection-to-presentation/)를 제공합니다. 이는 암호화가 아니지만 실수로 인한 편집 및 이동을 효과적으로 방지합니다.

**연결된 Excel 개체가 프레젠테이션을 열 때 "점프"하거나 크기가 변경되는 이유는 무엇인가요?**

PowerPoint가 연결된 OLE의 미리보기를 새로 고칠 수 있기 때문입니다. 안정적인 표시를 위해서는 [Worksheet Resizing에 대한 Working Solution](/slides/ko/cpp/working-solution-for-worksheet-resizing/)을 따라 프레임을 범위에 맞추거나, 범위를 고정 프레임에 맞게 스케일링하고 적절한 대체 이미지를 설정하세요.

**PPTX 형식에서 연결된 OLE 개체의 상대 경로가 유지됩니까?**

PPTX에서는 "상대 경로" 정보가 제공되지 않으며 전체 경로만 저장됩니다. 상대 경로는 오래된 PPT 형식에서만 지원됩니다. 이동성을 높이려면 신뢰할 수 있는 절대 경로나 접근 가능한 URI를 사용하거나 파일을 삽입하는 것이 좋습니다.