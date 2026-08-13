---
title: "C++를 사용한 프레젠테이션에서 OLE 관리"
linktitle: "OLE 관리"
type: docs
weight: 40
url: /ko/cpp/manage-ole/
keywords:
- "OLE 객체"
- "객체 연결 및 포함"
- "OLE 추가"
- "OLE 포함"
- "객체 추가"
- "객체 포함"
- "파일 추가"
- "파일 포함"
- "연결된 객체"
- "연결된 파일"
- "OLE 변경"
- "OLE 아이콘"
- "OLE 제목"
- "OLE 추출"
- "객체 추출"
- "파일 추출"
- "PowerPoint"
- "프레젠테이션"
- "C++"
- "Aspose.Slides"
description: "Aspose.Slides for C++를 사용하여 PowerPoint 및 OpenDocument 파일에서 OLE 객체 관리를 최적화합니다. OLE 콘텐츠를 손쉽게 삽입, 업데이트 및 내보낼 수 있습니다."
---
## **소개**

{{% alert title="Info" color="info" %}}

OLE(Object Linking & Embedding)은 하나의 애플리케이션에서 만든 데이터와 객체를 연결하거나 포함시켜 다른 애플리케이션에 삽입할 수 있게 해주는 Microsoft 기술입니다.

{{% /alert %}} 

MS Excel에서 만든 차트를 생각해 보세요. 그 차트를 PowerPoint 슬라이드에 배치하면 해당 Excel 차트는 OLE 객체가 됩니다. 

- OLE 객체는 아이콘 형태로 표시될 수 있습니다. 이 경우 아이콘을 두 번 클릭하면 차트가 연결된 애플리케이션(Excel)에서 열리거나, 객체를 열거나 편집할 애플리케이션을 선택하라는 메시지가 표시됩니다. 
- OLE 객체는 차트와 같은 실제 내용을 표시할 수도 있습니다. 이 경우 차트가 PowerPoint에서 활성화되고 차트 인터페이스가 로드되어 PowerPoint 내에서 차트 데이터를 수정할 수 있습니다. 

[Aspose.Slides for C++](https://products.aspose.com/slides/ko/cpp/)을 사용하면 OLE 객체를 OLE 객체 프레임([OleObjectFrame](https://reference.aspose.com/slides/ko/cpp/aspose.slides/oleobjectframe/))으로 슬라이드에 삽입할 수 있습니다.

## **슬라이드에 OLE 객체 프레임 추가**

Microsoft Excel에서 차트를 이미 만든 상태에서 Aspose.Slides for C++를 사용해 OLE 객체 프레임으로 슬라이드에 삽입하려면 다음과 같이 하면 됩니다:

1. [Presentation](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.presentation) 클래스를 인스턴스화합니다. 
2. 인덱스를 통해 슬라이드 참조를 가져옵니다. 
3. Excel 파일을 바이트 배열로 읽어옵니다. 
4. 바이트 배열 및 OLE 객체에 대한 기타 정보를 포함하여 슬라이드에 [OleObjectFrame](https://reference.aspose.com/slides/ko/cpp/aspose.slides/oleobjectframe/)을 추가합니다. 
5. 수정된 프레젠테이션을 PPTX 파일로 저장합니다. 

아래 예제에서는 Excel 파일에 있는 차트를 Aspose.Slides for C++를 사용해 [OleObjectFrame](https://reference.aspose.com/slides/ko/cpp/aspose.slides/oleobjectframe/)으로 슬라이드에 추가했습니다. **Note** [OleEmbeddedDataInfo](https://reference.aspose.com/slides/ko/cpp/aspose.slides.dom.ole/oleembeddeddatainfo/) 생성자는 두 번째 매개변수로 임베드 가능한 객체 확장자를 받습니다. 이 확장자는 PowerPoint가 파일 형식을 올바르게 해석하고 해당 OLE 객체를 열 적절한 애플리케이션을 선택하도록 도와줍니다.

``` cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <drawing/size_f.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slideSize = presentation->get_SlideSize()->get_Size();
auto slide = presentation->get_Slide(0);

// Prepare data for the OLE object.
auto fileData = File::ReadAllBytes(u"book.xlsx");
auto dataInfo = MakeObject<OleEmbeddedDataInfo>(fileData, u"xlsx");

// Add the OLE object frame to the slide.
slide->get_Shapes()->AddOleObjectFrame(0, 0, slideSize.get_Width(), slideSize.get_Height(), dataInfo);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **연결된 OLE 객체 프레임 추가**

Aspose.Slides for C++을 사용하면 데이터를 임베드하지 않고 파일에 대한 링크만으로 [OleObjectFrame](https://reference.aspose.com/slides/ko/cpp/aspose.slides/oleobjectframe/)을 추가할 수 있습니다.

다음 C++ 코드는 연결된 Excel 파일을 사용해 슬라이드에 [OleObjectFrame](https://reference.aspose.com/slides/ko/cpp/aspose.slides/oleobjectframe/)을 추가하는 방법을 보여 줍니다:

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

// 연결된 Excel 파일이 있는 OLE 객체 프레임을 추가합니다.
slide->get_Shapes()->AddOleObjectFrame(20, 20, 200, 150, u"Excel.Sheet.12", u"book.xlsx");

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **OLE 객체 프레임 접근**

슬라이드에 OLE 객체가 이미 임베드되어 있다면 다음과 같이 쉽게 찾거나 접근할 수 있습니다:

1. [Presentation](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.presentation) 클래스를 인스턴스화하여 임베드된 OLE 객체가 포함된 프레젠테이션을 로드합니다. 
2. 인덱스를 사용해 슬라이드 참조를 가져옵니다. 
3. [OleObjectFrame](https://reference.aspose.com/slides/ko/cpp/aspose.slides/oleobjectframe/) 형태에 접근합니다. 예제에서는 첫 번째 슬라이드에 하나의 형태만 있는 기존 PPTX를 사용했습니다. 해당 객체를 [IOleObjectFrame](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ioleobjectframe/)으로 *cast*했습니다. 이것이 접근하려는 OLE 객체 프레임입니다. 
4. OLE 객체 프레임에 접근하면 원하는 작업을 수행할 수 있습니다. 

아래 예제에서는 슬라이드에 임베드된 Excel 차트 객체와 해당 파일 데이터를 접근합니다.

``` cpp
#include <DOM/IOleEmbeddedDataInfo.h>
#include <DOM/IOleObjectFrame.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shape(0);

if (ObjectExt::Is<IOleObjectFrame>(shape))
{ 
    auto oleFrame = ExplicitCast<IOleObjectFrame>(shape);

    // 임베드된 파일 데이터를 가져옵니다.
    auto fileData = oleFrame->get_EmbeddedData()->get_EmbeddedFileData();

    // 임베드된 파일의 확장자를 가져옵니다.
    auto fileExtension = oleFrame->get_EmbeddedData()->get_EmbeddedFileExtension();

    // ...
}
```

### **연결된 OLE 객체 프레임 속성 접근**

Aspose.Slides를 사용하면 연결된 OLE 객체 프레임 속성에 접근할 수 있습니다.

다음 C++ 코드는 OLE 객체가 연결되어 있는지 확인하고 연결된 파일 경로를 얻는 방법을 보여 줍니다:

```cpp
#include <DOM/IOleObjectFrame.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/object_ext.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;

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

        // 연결된 파일의 상대 경로가 있으면 출력합니다.
        // 상대 경로는 PPT 프레젠테이션에만 포함될 수 있습니다.
        if (!String::IsNullOrEmpty(oleFrame->get_LinkPathRelative()))
        {
            std::wcout << L"OLE object frame relative path: " << oleFrame->get_LinkPathRelative() << std::endl;
        }
    }
}
```

## **OLE 객체 데이터 변경**

{{% alert color="info" %}} 

이 섹션에서는 아래 코드 예제가 [Aspose.Cells for C++](/cells/cpp/)를 사용합니다.

{{% /alert %}}

슬라이드에 OLE 객체가 이미 임베드되어 있다면 다음과 같이 해당 객체에 접근해 데이터를 수정할 수 있습니다:

1. [Presentation](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.presentation) 클래스를 인스턴스화하여 임베드된 OLE 객체가 포함된 프레젠테이션을 로드합니다. 
2. 인덱스를 통해 슬라이드 참조를 가져옵니다. 
3. [OLEObjectFrame](https://reference.aspose.com/slides/ko/cpp/aspose.slides/oleobjectframe/) 형태에 접근합니다. 예제에서는 첫 번째 슬라이드에 하나의 형태만 있는 기존 PPTX를 사용했습니다. 해당 객체를 [IOleObjectFrame](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ioleobjectframe/)으로 *cast*했습니다. 이것이 접근하려는 OLE 객체 프레임입니다. 
4. OLE 객체 프레임에 접근하면 원하는 작업을 수행할 수 있습니다. 
5. `Workbook` 객체를 생성하고 OLE 데이터를 접근합니다. 
6. 원하는 `Worksheet`에 접근해 데이터를 수정합니다. 
7. 업데이트된 `Workbook`을 스트림에 저장합니다. 
8. 스트림에서 OLE 객체 데이터를 교체합니다. 

아래 예제에서는 슬라이드에 임베드된 Excel 차트 객체를 접근하고 파일 데이터를 수정해 차트 데이터를 업데이트합니다.

``` cpp
#include <DOM/IOleObjectFrame.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <system/io/memory_stream.h>
#include <system/smart_ptr.h>
#include "Aspose.Cells/Cell.h"
#include "Aspose.Cells/Cells.h"
#include "Aspose.Cells/Initializer.h"
#include "Aspose.Cells/OoxmlSaveOptions.h"
#include "Aspose.Cells/SaveFormat.h"
#include "Aspose.Cells/U16String.h"
#include "Aspose.Cells/Vector.h"
#include "Aspose.Cells/Workbook.h"
#include "Aspose.Cells/Worksheet.h"
#include "Aspose.Cells/WorksheetCollection.h"
using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

// Aspose.Cells for C++는 해당 유형을 사용하기 전에 시작되어야 합니다.
Aspose::Cells::Startup();

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

// Get the first shape as an OLE object frame.
auto oleFrame = AsCast<IOleObjectFrame>(slide->get_Shape(0));

if (oleFrame != nullptr)
{
    auto oleStream = MakeObject<MemoryStream>(oleFrame->get_EmbeddedData()->get_EmbeddedFileData());

    // OLE 객체 데이터를 Workbook 객체로 읽어옵니다.
    auto oleArray = oleStream->ToArray();
    std::vector<uint8_t> workbookData(oleArray->data().begin(), oleArray->data().end());
    Aspose::Cells::Workbook workbook(Aspose::Cells::Vector<uint8_t>(workbookData.data(), workbookData.size()));

    // Workbook 데이터를 수정합니다.
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

Aspose::Cells::Cleanup();
```

## **슬라이드에 다른 파일 유형 임베드**

Excel 차트 외에도 Aspose.Slides for C++을 사용하면 HTML, PDF, ZIP 파일 등을 객체로 슬라이드에 임베드할 수 있습니다. 사용자가 삽입된 객체를 두 번 클릭하면 해당 프로그램에서 자동으로 열리거나, 열 프로그램을 선택하라는 메시지가 표시됩니다.

다음 C++ 코드는 HTML과 ZIP을 슬라이드에 임베드하는 방법을 보여 줍니다:

``` cpp
#include <DOM/IOleObjectFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

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

## **임베드된 객체의 파일 유형 설정**

프레젠테이션 작업 중에 오래된 OLE 객체를 새로운 것으로 교체하거나 지원되지 않는 OLE 객체를 지원되는 것으로 교체해야 할 때가 있습니다. Aspose.Slides for C++을 사용하면 임베드된 객체의 파일 유형을 설정해 OLE 프레임 데이터나 확장자를 업데이트할 수 있습니다.

다음 C++ 코드는 임베드된 OLE 객체의 파일 유형을 `zip`으로 설정하는 방법을 보여 줍니다:

``` cpp
#include <DOM/IOleObjectFrame.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
auto oleFrame = ExplicitCast<IOleObjectFrame>(slide->get_Shape(0));

auto fileExtension = oleFrame->get_EmbeddedData()->get_EmbeddedFileExtension();
auto fileData = oleFrame->get_EmbeddedData()->get_EmbeddedFileData();

std::wcout << L"Current embedded file extension is: " << fileExtension << std::endl;

// 파일 유형을 ZIP으로 변경합니다.
oleFrame->SetEmbeddedData(MakeObject<OleEmbeddedDataInfo>(fileData, u"zip"));

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **임베드된 객체의 아이콘 이미지와 제목 설정**

OLE 객체를 임베드하면 아이콘 이미지로 구성된 미리보기가 자동으로 추가됩니다. 이 미리보기는 사용자가 OLE 객체에 접근하거나 열기 전에 보게 되는 모습입니다. 미리보기에서 특정 이미지와 텍스트를 사용하려면 Aspose.Slides for C++을 통해 아이콘 이미지와 제목을 설정하면 됩니다.

다음 C++ 코드는 임베드된 객체에 아이콘 이미지와 제목을 설정하는 방법을 보여 줍니다: 

``` cpp
#include <DOM/IImageCollection.h>
#include <DOM/IOleObjectFrame.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

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

## **OLE 객체 프레임이 크기 조정 및 위치 변경되는 것을 방지**

연결된 OLE 객체를 프레젠테이션 슬라이드에 추가한 후 PowerPoint에서 프레젠테이션을 열면 링크 업데이트 여부를 묻는 메시지가 표시될 수 있습니다. “Update Links” 버튼을 클릭하면 PowerPoint가 연결된 OLE 객체의 데이터를 새로 고치고 객체 미리보기를 갱신하면서 OLE 객체 프레임의 크기와 위치가 변경될 수 있습니다. PowerPoint가 객체 데이터를 업데이트하도록 묻는 메시지를 방지하려면 [IOleObjectFrame](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ioleobjectframe/) 인터페이스의 `set_UpdateAutomatic` 메서드를 `false`로 설정합니다:

```cpp
#include <DOM/IOleObjectFrame.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
auto oleFrame = ExplicitCast<IOleObjectFrame>(slide->get_Shape(0));

oleFrame->set_UpdateAutomatic(false);
```

## **임베드된 파일 추출**

Aspose.Slides for C++을 사용하면 슬라이드에 OLE 객체로 임베드된 파일을 다음과 같이 추출할 수 있습니다:

1. 추출하려는 OLE 객체가 포함된 [Presentation](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.presentation) 인스턴스를 생성합니다. 
2. 프레젠테이션의 모든 형태를 순회하며 [OLEObjectFrame](https://reference.aspose.com/slides/ko/cpp/aspose.slides/oleobjectframe/) 형태에 접근합니다. 
3. OLE 객체 프레임에서 임베드된 파일 데이터를 가져와 디스크에 저장합니다. 

다음 C++ 코드는 슬라이드에 임베드된 파일을 OLE 객체 형태로 추출하는 방법을 보여 줍니다:

``` cpp
#include <DOM/IOleEmbeddedDataInfo.h>
#include <DOM/IOleObjectFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/io/file.h>
#include <system/object_ext.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

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

### 슬라이드를 PDF/이미지로 내보낼 때 OLE 콘텐츠가 렌더링됩니까?

슬라이드에 보이는 내용(아이콘/대체 이미지(미리보기))만 렌더링됩니다. “실시간” OLE 콘텐츠는 렌더링 중에 실행되지 않습니다. 필요하다면 내보낸 PDF에서 원하는 모습을 보장하도록 미리보기 이미지를 직접 설정하십시오.

### PowerPoint에서 사용자가 OLE 객체를 움직이거나 편집하지 못하도록 슬라이드에 잠그려면 어떻게 해야 하나요?

형태를 잠그세요: Aspose.Slides는 [shape-level locks](/slides/ko/cpp/applying-protection-to-presentation/)을 제공합니다. 이는 암호화가 아니지만 실수로 인한 편집 및 이동을 효과적으로 방지합니다.

### 연결된 Excel 객체를 열 때 “점프”하거나 크기가 바뀌는 이유는 무엇인가요?

PowerPoint가 연결된 OLE의 미리보기를 새로 고칠 수 있습니다. 안정적인 표시를 위해 [Working Solution for Worksheet Resizing](/slides/ko/cpp/working-solution-for-worksheet-resizing/) 방법을 따르세요—프레임을 범위에 맞추거나 범위를 고정 프레임에 맞게 스케일링하고 적절한 대체 이미지를 설정합니다.

### PPTX 형식에서 연결된 OLE 객체의 상대 경로가 보존됩니까?

PPTX에서는 “relative path” 정보가 제공되지 않으며 전체 경로만 저장됩니다. 상대 경로는 오래된 PPT 형식에서만 지원됩니다. 이동성을 위해 절대 경로나 접근 가능한 URI, 또는 임베드 방식을 사용하는 것이 좋습니다.