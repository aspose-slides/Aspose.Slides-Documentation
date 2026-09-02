---
title: Zarządzanie właściwościami prezentacji w C++
linktitle: Właściwości prezentacji
type: docs
weight: 70
url: /pl/cpp/presentation-properties/
keywords:
- właściwości PowerPoint
- właściwości prezentacji
- właściwości dokumentu
- wbudowane właściwości
- niestandardowe właściwości
- zaawansowane właściwości
- zarządzanie właściwościami
- modyfikowanie właściwości
- metadane dokumentu
- edytowanie metadanych
- język korekty
- domyślny język
- PowerPoint
- OpenDocument
- prezentacja
- C++
- Aspose.Slides
description: "Opanuj zarządzanie właściwościami prezentacji w Aspose.Slides dla C++ i usprawnij wyszukiwanie, branding oraz przepływ pracy w swoich plikach PowerPoint i OpenDocument."
---
## **Wprowadzenie**

Aspose.Slides obsługuje dwa typy właściwości dokumentu: **Wbudowane** i **Niestandardowe**. Oba typy właściwości można łatwo odczytać i zarządzać nimi przy użyciu API Aspose.Slides.

Aspose.Slides umożliwia pracę z właściwościami dokumentu prezentacji poprzez interfejs [IDocumentProperties](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.i_document_properties). Instancja tego interfejsu jest zwracana przez metodę [Presentation::get_DocumentProperties](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/get_documentproperties/). Poniższe przykłady pokazują, jak odczytywać, modyfikować i zarządzać tymi właściwościami.

{{% alert color="info" title="Uwaga" %}}
Należy pamiętać, że nie można ustawiać wartości pól **Application** i **Producer**, ponieważ w tych polach będą wyświetlane informacje o Aspose Ltd. oraz Aspose.Slides for C++ x.x.x.
{{% /alert %}} 

## **Zarządzanie właściwościami prezentacji**

Microsoft PowerPoint udostępnia funkcję dodawania właściwości do plików prezentacji. Te właściwości dokumentu pozwalają przechowywać przydatne informacje razem z dokumentami (plikami prezentacji). Istnieją dwa rodzaje właściwości dokumentu:

- Właściwości systemowe (Wbudowane)  
- Właściwości definiowane przez użytkownika (Niestandardowe)

**Wbudowane** właściwości zawierają ogólne informacje o dokumencie, takie jak tytuł dokumentu, nazwisko autora, statystyki dokumentu itp. **Niestandardowe** właściwości to pary **Nazwa/Wartość** definiowane przez użytkownika. Korzystając z Aspose.Slides for C++, programiści mogą odczytywać i modyfikować zarówno wbudowane, jak i niestandardowe właściwości. Microsoft PowerPoint 2007 umożliwia zarządzanie właściwościami dokumentu plików prezentacji. Wystarczy kliknąć ikonę Office, a następnie wybrać **Prepare | Properties | Advanced Properties** w Microsoft PowerPoint 2007. Po wybraniu pozycji menu **Advanced Properties** pojawi się okno dialogowe umożliwiające zarządzanie właściwościami dokumentu pliku PowerPoint. W **Properties Dialog** można zobaczyć wiele zakładek, takich jak **General, Summary, Statistics, Contents i Custom**. Wszystkie te zakładki pozwalają konfigurować różne rodzaje informacji związane z plikami PowerPoint. Zakładka **Custom** służy do zarządzania niestandardowymi właściwościami plików PowerPoint.

## **Dostęp do wbudowanych właściwości**

Właściwości udostępniane przez obiekt **IDocumentProperties** obejmują: **Creator(Author)**, **Description**, **KeyWords**, **Created** (Data utworzenia), **Modified** (Data modyfikacji), **Printed** (Data ostatniego wydruku), **LastModifiedBy**, **Keywords**, **SharedDoc** (Czy jest współdzielony między różnymi producentami?), **PresentationFormat**, **Subject** oraz **Title**.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessBuiltinProperties-AccessBuiltinProperties.cpp" >}}

## **Modyfikacja wbudowanych właściwości**

Modyfikowanie wbudowanych właściwości plików prezentacji jest tak proste, jak ich odczytywanie. Wystarczy przypisać wartość ciągu znaków do dowolnej żądanej właściwości, a wartość zostanie zmieniona. W poniższym przykładzie pokazano, jak zmodyfikować wbudowane właściwości dokumentu prezentacji.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-UpdatePresentationProperties-UpdatePresentationProperties.cpp" >}}

## **Dodawanie niestandardowych właściwości prezentacji**

Aspose.Slides for C++ umożliwia programistom dodawanie wartości niestandardowych do właściwości dokumentu prezentacji. Poniżej znajduje się przykład, który pokazuje, jak ustawić niestandardowe właściwości dla prezentacji.

``` cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Utwórz obiekt klasy Presentation
auto presentation = System::MakeObject<Presentation>();

// Pobieranie właściwości dokumentu
auto documentProperties = presentation->get_DocumentProperties();

// Dodawanie własnych właściwości
documentProperties->idx_set(u"New Custom", ObjectExt::Box<int32_t>(12));
documentProperties->idx_set(u"My Name", ObjectExt::Box<String>(u"Mudassir"));
documentProperties->idx_set(u"Custom", ObjectExt::Box<int32_t>(124));

// Pobieranie nazwy właściwości pod określonym indeksem
String getPropertyName = documentProperties->GetCustomPropertyName(2);

// Usuwanie wybranej właściwości
documentProperties->RemoveCustomProperty(getPropertyName);

// Zapisywanie prezentacji
presentation->Save(u"CustomDocumentProperties_out.pptx", SaveFormat::Pptx);
```

## **Dostęp i modyfikacja niestandardowych właściwości**

Aspose.Slides for C++ umożliwia programistom dostęp do wartości niestandardowych właściwości. Poniżej znajduje się przykład, który pokazuje, jak odczytać i zmodyfikować wszystkie te niestandardowe właściwości dla prezentacji.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessModifyingProperties-AccessModifyingProperties.cpp" >}}

## **Ustaw język korekty**

Aspose.Slides udostępnia właściwość [LanguageId](https://reference.aspose.com/slides/pl/cpp/aspose.slides/baseportionformat/set_languageid/) (eksponowaną przez klasę [PortionFormat](https://reference.aspose.com/slides/pl/cpp/aspose.slides/portionformat/)), aby umożliwić ustawienie języka korekty dla dokumentu PowerPoint. Język korekty to język, dla którego sprawdzane są pisownia i gramatyka w PowerPoint.

Ten kod C++ pokazuje, jak ustawić język korekty dla PowerPoint:

```c++
#include <DOM/AutoShape.h>
#include <DOM/Fonts/FontData.h>
#include <DOM/IFontData.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
using namespace Aspose::Slides;

System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"sample.pptx");
System::SharedPtr<AutoShape> autoShape = System::ExplicitCast<AutoShape>(pres->get_Slide(0)->get_Shape(0));

System::SharedPtr<IParagraph> paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
System::SharedPtr<IPortionCollection> portions = paragraph->get_Portions();
portions->Clear();

System::SharedPtr<Portion> newPortion = System::MakeObject<Portion>();

System::SharedPtr<IFontData> font = System::MakeObject<FontData>(u"SimSun");
System::SharedPtr<IPortionFormat> portionFormat = newPortion->get_PortionFormat();
portionFormat->set_ComplexScriptFont(font);
portionFormat->set_EastAsianFont(font);
portionFormat->set_LatinFont(font);

portionFormat->set_LanguageId(u"zh-CN");
// ustaw Id języka korekty

newPortion->set_Text(u"1。");
portions->Add(newPortion);
```

## **Ustaw domyślny język**

Ten kod C++ pokazuje, jak ustawić domyślny język dla całej prezentacji PowerPoint:

```c++
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/console.h>
using namespace Aspose::Slides;

System::SharedPtr<LoadOptions> loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_DefaultTextLanguage(u"en-US");

System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(loadOptions);

// Dodaje nowy prostokątny kształt z tekstem
System::SharedPtr<IAutoShape> shp = pres->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 150.0f, 50.0f);
System::SharedPtr<ITextFrame> textFrame = shp->get_TextFrame();
textFrame->set_Text(u"New Text");

// Sprawdza język pierwszej części
System::Console::WriteLine(textFrame->get_Paragraph(0)->get_Portion(0)->get_PortionFormat()->get_LanguageId());
```

## **Przykład na żywo**

Wypróbuj aplikację online [**Aspose.Slides Metadata**](https://products.aspose.app/slides/pl/metadata), aby zobaczyć, jak pracować z właściwościami dokumentu za pomocą API Aspose.Slides:

[![Wyświetl i edytuj metadane PowerPoint](slides-metadata.png)](https://products.aspose.app/slides/pl/metadata)

## **FAQ**

**Jak mogę usunąć wbudowaną właściwość z prezentacji?**

Wbudowane właściwości są integralną częścią prezentacji i nie mogą być całkowicie usunięte. Można jednak zmienić ich wartości lub, jeśli dana właściwość na to pozwala, ustawić je jako puste.

**Co się stanie, jeśli dodam niestandardową właściwość, która już istnieje?**

Jeśli dodasz niestandardową właściwość, która już istnieje, jej bieżąca wartość zostanie nadpisana nową. Nie musisz usuwać ani sprawdzać właściwości wcześniej, ponieważ Aspose.Slides automatycznie aktualizuje wartość właściwości.

**Czy mogę uzyskać dostęp do właściwości prezentacji bez pełnego wczytywania prezentacji?**

Tak. użyj [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/), a następnie [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/), aby odczytać zapisane metadane dokumentu bez tworzenia instancji [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/). Zobacz [Build a Lightweight Presentation Inventory](/slides/pl/cpp/examine-presentation/) po pełny przykład raportowania i ograniczenia zależne od formatu.