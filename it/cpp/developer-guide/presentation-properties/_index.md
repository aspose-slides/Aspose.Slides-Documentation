---
title: Gestisci le proprietà della presentazione in C++
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
- Modifica dei metadati
- Lingua di correzione
- Lingua predefinita
- PowerPoint
- OpenDocument
- presentazione
- C++
- Aspose.Slides
description: "Gestisci le proprietà delle presentazioni in Aspose.Slides per C++ e ottimizza ricerca, branding e flusso di lavoro nei tuoi file PowerPoint e OpenDocument."
---
## **Introduzione**

Aspose.Slides supporta due tipi di proprietà del documento: **Built-in** e **Custom**. Entrambi questi tipi di proprietà possono essere facilmente accessi e gestiti tramite l'API di Aspose.Slides.

Aspose.Slides consente di lavorare con le proprietà del documento della presentazione attraverso l'interfaccia [IDocumentProperties](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.i_document_properties). Un'istanza di questa interfaccia viene restituita dal metodo [Presentation::get_DocumentProperties](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/get_documentproperties/). Gli esempi seguenti mostrano come leggere, modificare e gestire queste proprietà.

{{% alert color="primary" %}} 

Si noti che non è possibile impostare valori per i campi **Application** e **Producer**, poiché Aspose Ltd. e Aspose.Slides for C++ x.x.x verranno visualizzati in questi campi.

{{% /alert %}} 

## **Gestire le proprietà della presentazione**

Microsoft PowerPoint fornisce una funzionalità per aggiungere alcune proprietà ai file di presentazione. Queste proprietà del documento consentono di memorizzare informazioni utili insieme ai documenti (file di presentazione). Esistono due tipologie di proprietà del documento, come segue

- Proprietà definite dal sistema (Built-in)  
- Proprietà definite dall'utente (Custom)

**Built-in** le proprietà contengono informazioni generali sul documento, come titolo, nome dell'autore, statistiche del documento e così via. **Custom** le proprietà sono quelle definite dagli utenti come coppie **Name/Value**, dove sia il nome sia il valore sono specificati dall'utente. Utilizzando Aspose.Slides for C++, gli sviluppatori possono accedere e modificare i valori delle proprietà built-in così come delle proprietà custom. Microsoft PowerPoint 2007 consente di gestire le proprietà del documento dei file di presentazione. Basta fare clic sull'icona Office e successivamente sul menu **Prepare | Properties | Advanced Properties** di Microsoft PowerPoint 2007. Dopo aver selezionato la voce **Advanced Properties**, appare una finestra di dialogo che permette di gestire le proprietà del file PowerPoint. Nella **Properties Dialog**, è possibile vedere diverse schede come **General, Summary, Statistics, Contents e Custom**. Tutte queste schede consentono di configurare diversi tipi di informazioni relative ai file PowerPoint. La scheda **Custom** è utilizzata per gestire le proprietà personalizzate dei file PowerPoint.

## **Accedere alle proprietà Built-in**

Queste proprietà esposte dall'oggetto **IDocumentProperties** includono: **Creator(Author)**, **Description**, **KeyWords**, **Created** (Data di creazione), **Modified** (Data di modifica), **Printed** (Data dell'ultima stampa), **LastModifiedBy**, **Keywords**, **SharedDoc** (È condiviso tra più produttori?), **PresentationFormat**, **Subject** e **Title**.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessBuiltinProperties-AccessBuiltinProperties.cpp" >}}

## **Modificare le proprietà Built-in**

Modificare le proprietà built-in dei file di presentazione è semplice quanto accedervi. È sufficiente assegnare una stringa a qualsiasi proprietà desiderata e il valore della proprietà verrà modificato. Nell'esempio riportato di seguito, dimostriamo come modificare le proprietà built-in del documento della presentazione.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-UpdatePresentationProperties-UpdatePresentationProperties.cpp" >}}

## **Aggiungere proprietà Custom alla presentazione**

Aspose.Slides for C++ consente anche agli sviluppatori di aggiungere valori custom per le proprietà del documento della presentazione. Di seguito è riportato un esempio che mostra come impostare le proprietà custom per una presentazione.

``` cpp
// Istanzia la classe Presentation
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

## **Accedere e modificare le proprietà Custom**

Aspose.Slides for C++ consente anche agli sviluppatori di accedere ai valori delle proprietà custom. Di seguito è riportato un esempio che mostra come accedere e modificare tutte queste proprietà custom per una presentazione.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessModifyingProperties-AccessModifyingProperties.cpp" >}}

## **Impostare la lingua di correzione**

Aspose.Slides fornisce la proprietà [LanguageId](https://reference.aspose.com/slides/it/cpp/aspose.slides/baseportionformat/set_languageid/) (esposta dalla classe [PortionFormat](https://reference.aspose.com/slides/it/cpp/aspose.slides/portionformat/)) per consentire di impostare la lingua di correzione per un documento PowerPoint. La lingua di correzione è la lingua per la quale vengono controllate ortografia e grammatica in PowerPoint.

Questo codice C++ mostra come impostare la lingua di correzione per un PowerPoint:

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(pptxFileName);
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
// imposta l'Id di una lingua di correzione

newPortion->set_Text(u"1。");
portions->Add(newPortion);
```

## **Impostare la lingua predefinita**

Questo codice C++ mostra come impostare la lingua predefinita per un'intera presentazione PowerPoint:

```c++
System::SharedPtr<LoadOptions> loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_DefaultTextLanguage(u"en-US");

System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(loadOptions);

// Aggiunge una nuova forma rettangolare con testo
System::SharedPtr<IAutoShape> shp = pres->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 150.0f, 50.0f);
System::SharedPtr<ITextFrame> textFrame = shp->get_TextFrame();
textFrame->set_Text(u"New Text");

// Verifica la lingua della prima porzione
System::Console::WriteLine(textFrame->get_Paragraph(0)->get_Portion(0)->get_PortionFormat()->get_LanguageId());
```

## **Esempio live**

Prova l'app online [**Aspose.Slides Metadata**](https://products.aspose.app/slides/it/metadata) per vedere come lavorare con le proprietà del documento tramite l'API di Aspose.Slides:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/it/metadata)

## ***FAQ**

**Come posso rimuovere una proprietà built-in da una presentazione?**

Le proprietà built-in sono parte integrante della presentazione e non possono essere rimosse completamente. Tuttavia, è possibile modificarne i valori o impostarle a vuoto se la proprietà lo consente.

**Cosa succede se aggiungo una proprietà custom che esiste già?**

Se aggiungi una proprietà custom che esiste già, il valore corrente verrà sovrascritto con quello nuovo. Non è necessario rimuovere o verificare la proprietà in anticipo, poiché Aspose.Slides aggiorna automaticamente il valore della proprietà.

**Posso accedere alle proprietà della presentazione senza caricare completamente la presentazione?**

Sì, è possibile accedere alle proprietà della presentazione senza caricarla completamente utilizzando il metodo `GetPresentationInfo` della classe [PresentationFactory](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentationfactory/). Successivamente, utilizza il metodo `ReadDocumentProperties` fornito dall'interfaccia [IPresentationInfo](https://reference.aspose.com/slides/it/cpp/aspose.slides/ipresentationinfo/) per leggere le proprietà in modo efficiente, risparmiando memoria e migliorando le prestazioni.