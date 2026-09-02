---
title: Gestisci le proprietà della presentazione in C++
linktitle: Proprietà della presentazione
type: docs
weight: 70
url: /it/cpp/presentation-properties/
keywords:
- Proprietà PowerPoint
- proprietà della presentazione
- proprietà del documento
- proprietà integrate
- proprietà personalizzate
- proprietà avanzate
- gestire le proprietà
- modificare le proprietà
- metadati del documento
- modificare i metadati
- lingua di correzione
- lingua predefinita
- PowerPoint
- OpenDocument
- presentazione
- C++
- Aspose.Slides
description: "Gestisci le proprietà delle presentazioni in Aspose.Slides per C++ e semplifica ricerca, branding e flusso di lavoro nei tuoi file PowerPoint e OpenDocument."
---
## **Introduzione**

Aspose.Slides supporta due tipi di proprietà del documento: **Built-in** e **Custom**. Entrambi questi tipi di proprietà possono essere facilmente accessibili e gestiti tramite l'API di Aspose.Slides.

Aspose.Slides consente di lavorare con le proprietà del documento di presentazione tramite l'interfaccia [IDocumentProperties](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.i_document_properties). Un'istanza di questa interfaccia viene restituita dal metodo [Presentation::get_DocumentProperties](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/get_documentproperties/). I seguenti esempi mostrano come leggere, modificare e gestire queste proprietà.

{{% alert color="info" title="Note" %}}
Si prega di notare che non è possibile impostare valori nei campi **Application** e **Producer**, poiché verranno mostrati Aspose Ltd. e Aspose.Slides per C++ x.x.x in questi campi.
{{% /alert %}} 

## **Gestire le proprietà della presentazione**

Microsoft PowerPoint fornisce una funzionalità per aggiungere alcune proprietà ai file di presentazione. Queste proprietà del documento consentono di memorizzare informazioni utili insieme ai documenti (file di presentazione). Esistono due tipologie di proprietà del documento, come segue

- Proprietà definite dal sistema (Built-in)
- Proprietà definite dall'utente (Custom)

Le proprietà **Built-in** contengono informazioni generali sul documento, come il titolo del documento, il nome dell'autore, le statistiche del documento e così via. Le proprietà **Custom** sono quelle definite dagli utenti come coppie **Name/Value**, dove sia il nome che il valore sono definiti dall'utente. Utilizzando Aspose.Slides per C++, gli sviluppatori possono accedere e modificare i valori delle proprietà built-in così come delle proprietà custom. Microsoft PowerPoint 2007 consente di gestire le proprietà del documento dei file di presentazione. Tutto quello che devi fare è fare clic sull'icona Office e poi sull'elemento di menu **Prepare | Properties | Advanced Properties** di Microsoft PowerPoint 2007. Dopo aver selezionato l'elemento di menu **Advanced Properties**, appare una finestra di dialogo che consente di gestire le proprietà del documento del file PowerPoint. Nella **Properties Dialog**, puoi vedere molte schede come **General, Summary, Statistics, Contents and Custom**. Tutte queste schede consentono di configurare diversi tipi di informazioni relative ai file PowerPoint. La scheda **Custom** è utilizzata per gestire le proprietà custom dei file PowerPoint.

## **Accedere alle proprietà Built-in**

Queste proprietà esposte dall'oggetto **IDocumentProperties** includono: **Creator(Author)**, **Description**, **KeyWords**, **Created** (Data di creazione), **Modified** (Data di modifica), **Printed** (Data dell'ultima stampa), **LastModifiedBy**, **Keywords**, **SharedDoc** (è condiviso tra diversi produttori?), **PresentationFormat**, **Subject** e **Title**

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessBuiltinProperties-AccessBuiltinProperties.cpp" >}}

## **Modificare le proprietà Built-in**

Modificare le proprietà built-in dei file di presentazione è semplice quanto accedervi. È sufficiente assegnare un valore stringa a qualsiasi proprietà desiderata e il valore della proprietà verrà modificato. Nell'esempio mostrato di seguito, abbiamo dimostrato come è possibile modificare le proprietà built-in del documento di presentazione.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-UpdatePresentationProperties-UpdatePresentationProperties.cpp" >}}

## **Aggiungere proprietà custom alla presentazione**

Aspose.Slides per C++ consente anche agli sviluppatori di aggiungere valori custom per le proprietà del documento della presentazione. Di seguito è riportato un esempio che mostra come impostare le proprietà custom per una presentazione.

``` cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Istanzia la classe Presentation
auto presentation = System::MakeObject<Presentation>();

// Recupero delle proprietà del documento
auto documentProperties = presentation->get_DocumentProperties();

// Aggiunta di proprietà personalizzate
documentProperties->idx_set(u"New Custom", ObjectExt::Box<int32_t>(12));
documentProperties->idx_set(u"My Name", ObjectExt::Box<String>(u"Mudassir"));
documentProperties->idx_set(u"Custom", ObjectExt::Box<int32_t>(124));

// Recupero del nome della proprietà a un indice specifico
String getPropertyName = documentProperties->GetCustomPropertyName(2);

// Rimozione della proprietà selezionata
documentProperties->RemoveCustomProperty(getPropertyName);

// Salvataggio della presentazione
presentation->Save(u"CustomDocumentProperties_out.pptx", SaveFormat::Pptx);
```

## **Accedere e modificare le proprietà Custom**

Aspose.Slides per C++ consente anche agli sviluppatori di accedere ai valori delle proprietà custom. Di seguito è riportato un esempio che mostra come è possibile accedere e modificare tutte queste proprietà custom per una presentazione.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessModifyingProperties-AccessModifyingProperties.cpp" >}}

## **Impostare la lingua di correzione**

Aspose.Slides fornisce la proprietà [LanguageId](https://reference.aspose.com/slides/it/cpp/aspose.slides/baseportionformat/set_languageid/) (esposta dalla classe [PortionFormat](https://reference.aspose.com/slides/it/cpp/aspose.slides/portionformat/)) per consentire di impostare la lingua di correzione per un documento PowerPoint. La lingua di correzione è la lingua per cui l'ortografia e la grammatica in PowerPoint vengono verificate.

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
// Imposta l'ID di una lingua di correzione

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

Prova l'app online [**Aspose.Slides Metadata**](https://products.aspose.app/slides/it/metadata) per vedere come lavorare con le proprietà del documento tramite l'API di Aspose.Slides:

[![Visualizza e modifica i metadati PowerPoint](slides-metadata.png)](https://products.aspose.app/slides/it/metadata)

## **FAQ**

**Come posso rimuovere una proprietà built-in da una presentazione?**

Le proprietà built-in sono parte integrante della presentazione e non possono essere rimosse completamente. Tuttavia, è possibile modificare i loro valori o impostarle a vuoto, se consentito dalla proprietà specifica.

**Cosa succede se aggiungo una proprietà custom che esiste già?**

Se aggiungi una proprietà custom già esistente, il suo valore corrente sarà sovrascritto con quello nuovo. Non è necessario rimuovere o verificare la proprietà in anticipo, poiché Aspose.Slides aggiorna automaticamente il valore della proprietà.

**Posso accedere alle proprietà della presentazione senza caricare completamente la presentazione?**

Sì. Utilizza [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/it/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) e poi [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/it/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) per leggere i metadati del documento memorizzati senza creare un'istanza di [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/). Consulta [Build a Lightweight Presentation Inventory](/slides/it/cpp/examine-presentation/) per un esempio completo di reportistica e le limitazioni specifiche del formato.