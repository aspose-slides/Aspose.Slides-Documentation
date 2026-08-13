---
title: Gestire le proprietà della presentazione in C++
linktitle: Proprietà della presentazione
type: docs
weight: 70
url: /it/cpp/presentation-properties/
keywords:
- Proprietà PowerPoint
- Proprietà della presentazione
- Proprietà del documento
- Proprietà integrate
- Proprietà personalizzate
- Proprietà avanzate
- Gestire le proprietà
- Modificare le proprietà
- Metadati del documento
- Modificare i metadati
- Lingua di verifica
- Lingua predefinita
- PowerPoint
- OpenDocument
- presentazione
- C++
- Aspose.Slides
description: "Gestisci al meglio le proprietà della presentazione in Aspose.Slides per C++ e ottimizza la ricerca, il branding e il flusso di lavoro nei tuoi file PowerPoint e OpenDocument."
---
## **Introduzione**

Aspose.Slides supporta due tipi di proprietà del documento: **Integrate** e **Personalizzate**. Entrambi i tipi di proprietà possono essere facilmente accessi e gestiti utilizzando l'API Aspose.Slides.

Aspose.Slides consente di lavorare con le proprietà del documento della presentazione tramite l'interfaccia [IDocumentProperties](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.i_document_properties). Un'istanza di questa interfaccia viene restituita dal metodo [Presentation::get_DocumentProperties](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/get_documentproperties/). Gli esempi seguenti mostrano come leggere, modificare e gestire queste proprietà.

{{% alert color="info" %}} 
Si noti che non è possibile impostare valori nei campi **Application** e **Producer**, poiché verranno visualizzati “Aspose Ltd.” e “Aspose.Slides for C++ x.x.x” in questi campi.
{{% /alert %}} 

## **Gestire le proprietà della presentazione**

Microsoft PowerPoint fornisce una funzionalità per aggiungere alcune proprietà ai file di presentazione. Queste proprietà del documento consentono di memorizzare informazioni utili insieme ai documenti (file di presentazione). Esistono due tipologie di proprietà del documento:

- Proprietà di sistema (Integrate)
- Proprietà definite dall'utente (Personalizzate)

Le proprietà **Integrate** contengono informazioni generali sul documento, come titolo, nome dell'autore, statistiche del documento e così via. Le proprietà **Personalizzate** sono quelle definite dagli utenti come coppie **Nome/Valore**, in cui sia il nome sia il valore sono specificati dall'utente. Utilizzando Aspose.Slides per C++, gli sviluppatori possono accedere e modificare i valori delle proprietà integrate così come di quelle personalizzate. Microsoft PowerPoint 2007 consente di gestire le proprietà del documento dei file di presentazione. Basta fare clic sull'icona Office e quindi sul menu **Prepare | Properties | Advanced Properties** di Microsoft PowerPoint 2007. Dopo aver selezionato **Advanced Properties**, appare una finestra di dialogo che consente di gestire le proprietà del documento del file PowerPoint. Nella **Properties Dialog**, è possibile vedere diverse schede come **General, Summary, Statistics, Contents e Custom**. Tutte queste schede permettono di configurare diversi tipi di informazioni relative ai file PowerPoint. La scheda **Custom** è utilizzata per gestire le proprietà personalizzate dei file PowerPoint.

## **Accedere alle proprietà integrate**

Queste proprietà esposte dall'oggetto **IDocumentProperties** includono: **Creator(Author)**, **Description**, **KeyWords**, **Created** (Data di creazione), **Modified** (Data di modifica), **Printed** (Data dell'ultima stampa), **LastModifiedBy**, **Keywords**, **SharedDoc** (È condiviso tra diversi produttori?), **PresentationFormat**, **Subject** e **Title**.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessBuiltinProperties-AccessBuiltinProperties.cpp" >}}

## **Modificare le proprietà integrate**

Modificare le proprietà integrate dei file di presentazione è facile quanto accedervi. È sufficiente assegnare una stringa a qualsiasi proprietà desiderata e il valore verrà modificato. Nell'esempio riportato di seguito, dimostriamo come modificare le proprietà integrate del documento della presentazione.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-UpdatePresentationProperties-UpdatePresentationProperties.cpp" >}}

## **Aggiungere proprietà personalizzate alla presentazione**

Aspose.Slides per C++ consente anche agli sviluppatori di aggiungere valori personalizzati alle proprietà del documento della presentazione. Un esempio è mostrato di seguito, che illustra come impostare le proprietà personalizzate per una presentazione.

``` cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Istanziare la classe Presentation
auto presentation = System::MakeObject<Presentation>();

// Ottenere le proprietà del documento
auto documentProperties = presentation->get_DocumentProperties();

// Aggiungere proprietà personalizzate
documentProperties->idx_set(u"New Custom", ObjectExt::Box<int32_t>(12));
documentProperties->idx_set(u"My Name", ObjectExt::Box<String>(u"Mudassir"));
documentProperties->idx_set(u"Custom", ObjectExt::Box<int32_t>(124));

// Ottenere il nome della proprietà a un indice specifico
String getPropertyName = documentProperties->GetCustomPropertyName(2);

// Rimuovere la proprietà selezionata
documentProperties->RemoveCustomProperty(getPropertyName);

// Salvare la presentazione
presentation->Save(u"CustomDocumentProperties_out.pptx", SaveFormat::Pptx);
```

## **Accedere e modificare le proprietà personalizzate**

Aspose.Slides per C++ consente inoltre agli sviluppatori di accedere ai valori delle proprietà personalizzate. Un esempio è mostrato di seguito, che spiega come accedere e modificare tutte queste proprietà personalizzate per una presentazione.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessModifyingProperties-AccessModifyingProperties.cpp" >}}

## **Impostare la lingua di revisione**

Aspose.Slides fornisce la proprietà [LanguageId](https://reference.aspose.com/slides/it/cpp/aspose.slides.baseportionformat/set_languageid/) (esposta dalla classe [PortionFormat](https://reference.aspose.com/slides/it/cpp/aspose.slides/portionformat/)) per consentire di impostare la lingua di revisione per un documento PowerPoint. La lingua di revisione è la lingua per la quale vengono controllati ortografia e grammatica in PowerPoint.

Questo codice C++ mostra come impostare la lingua di revisione per un PowerPoint:

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
// imposta l'Id di una lingua di verifica

newPortion->set_Text(u"1。");
portions->Add(newPortion);
```

## **Impostare la lingua predefinita**

Questo codice C++ mostra come impostare la lingua predefinita per un'intera presentazione PowerPoint:

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

// Aggiunge una nuova forma rettangolare con testo
System::SharedPtr<IAutoShape> shp = pres->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 150.0f, 50.0f);
System::SharedPtr<ITextFrame> textFrame = shp->get_TextFrame();
textFrame->set_Text(u"New Text");

// Controlla la lingua della prima porzione
System::Console::WriteLine(textFrame->get_Paragraph(0)->get_Portion(0)->get_PortionFormat()->get_LanguageId());
```

## **Esempio live**

Prova l'app online [**Aspose.Slides Metadata**](https://products.aspose.app/slides/it/metadata) per vedere come lavorare con le proprietà del documento tramite l'API Aspose.Slides:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/it/metadata)

## ***FAQ**

### Come posso rimuovere una proprietà integrata da una presentazione?

Le proprietà integrate sono parte integrante della presentazione e non possono essere rimosse completamente. Tuttavia, è possibile modificarne i valori o impostarle a vuoto, se consentito dalla specifica proprietà.

### Cosa succede se aggiungo una proprietà personalizzata che esiste già?

Se si aggiunge una proprietà personalizzata già presente, il suo valore esistente verrà sovrascritto con quello nuovo. Non è necessario rimuovere o verificare la proprietà in anticipo, poiché Aspose.Slides aggiorna automaticamente il valore della proprietà.

### Posso accedere alle proprietà della presentazione senza caricare completamente la presentazione?

Sì, è possibile accedere alle proprietà della presentazione senza caricare completamente la presentazione utilizzando il metodo `GetPresentationInfo` della classe [PresentationFactory](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentationfactory/). Successivamente, utilizzare il metodo `ReadDocumentProperties` fornito dall'interfaccia [IPresentationInfo](https://reference.aspose.com/slides/it/cpp/aspose.slides/ipresentationinfo/) per leggere le proprietà in modo efficiente, risparmiando memoria e migliorando le prestazioni.