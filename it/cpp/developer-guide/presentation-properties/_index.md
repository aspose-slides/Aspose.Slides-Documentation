---
title: Gestire le proprietà della presentazione in C++
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
description: "Gestisci le proprietà delle presentazioni in Aspose.Slides per C++ e ottimizza la ricerca, il branding e il flusso di lavoro nei tuoi file PowerPoint e OpenDocument."
---
## **Introduzione**

Aspose.Slides supporta due tipi di proprietà del documento: **Built-in** e **Custom**. Entrambi questi tipi di proprietà possono essere facilmente accessibili e gestiti utilizzando l'API di Aspose.Slides.

Aspose.Slides consente di lavorare con le proprietà del documento della presentazione tramite l'interfaccia [IDocumentProperties](https://reference.aspose.com/slides/it/cpp/aspose.slides/idocumentproperties/). Un'istanza di questa interfaccia viene restituita da [IPresentation::get_DocumentProperties](https://reference.aspose.com/slides/it/cpp/aspose.slides/ipresentation/get_documentproperties/). I seguenti esempi mostrano come leggere, modificare e gestire queste proprietà.

{{% alert color="info" title="Note" %}}
Si prega di notare che non è possibile impostare valori per i campi **Application** e **Producer**, poiché verranno visualizzati Aspose Ltd. e Aspose.Slides for C++ x.x.x in questi campi.
{{% /alert %}} 

## **Gestire le proprietà della presentazione**

Microsoft PowerPoint fornisce una funzionalità per aggiungere alcune proprietà ai file di presentazione. Queste proprietà del documento consentono di memorizzare informazioni utili insieme ai documenti (file di presentazione). Esistono due tipi di proprietà del documento come segue

- Proprietà definite dal sistema (Built-in)
- Proprietà definite dall'utente (Custom)

Le proprietà **Built-in** contengono informazioni generali sul documento come titolo del documento, nome dell'autore, statistiche del documento e così via. Le proprietà **Custom** sono quelle definite dagli utenti come coppie **Name/Value**, dove sia il nome che il valore sono definiti dall'utente. Utilizzando Aspose.Slides for C++, gli sviluppatori possono accedere e modificare i valori delle proprietà built-in così come delle proprietà custom. Microsoft PowerPoint 2007 consente di gestire le proprietà del documento dei file di presentazione. Tutto ciò che devi fare è fare clic sull'icona Office e poi sulla voce di menu **Prepare | Properties | Advanced Properties** di Microsoft PowerPoint 2007. Dopo aver selezionato la voce di menu **Advanced Properties**, compare una finestra di dialogo che consente di gestire le proprietà del documento del file PowerPoint. Nella **Properties Dialog**, puoi vedere che ci sono molte schede come **General, Summary, Statistics, Contents and Custom**. Tutte queste schede consentono di configurare diversi tipi di informazioni relative ai file PowerPoint. La scheda **Custom** è usata per gestire le proprietà personalizzate dei file PowerPoint.

## **Leggere le proprietà pubbliche da una presentazione crittografata**

Una password di apertura normalmente protegge sia il contenuto della presentazione sia le proprietà del documento. Quando una presentazione è crittografata passando `false` a [IProtectionManager::set_EncryptDocumentProperties](https://reference.aspose.com/slides/it/cpp/aspose.slides/iprotectionmanager/set_encryptdocumentproperties/), le sue proprietà del documento rimangono pubbliche. Un'applicazione può quindi passare `true` a [LoadOptions::set_OnlyLoadDocumentProperties](https://reference.aspose.com/slides/it/cpp/aspose.slides/loadoptions/set_onlyloaddocumentproperties/) e leggere i metadati pubblici senza fornire la password di apertura.

`set_OnlyLoadDocumentProperties` controlla cosa carica Aspose.Slides; non decritta nulla. Se le proprietà erano incluse nella crittografia, il loro caricamento senza password fallisce. Se la presentazione non è crittografata, l'opzione è ignorata e l'intera presentazione viene caricata.

Il seguente esempio verifica la modalità di caricamento tramite [IProtectionManager::get_IsOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/it/cpp/aspose.slides/iprotectionmanager/get_isonlydocumentpropertiesloaded/) e poi legge le proprietà built-in tramite [IPresentation::get_DocumentProperties](https://reference.aspose.com/slides/it/cpp/aspose.slides/ipresentation/get_documentproperties/):

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IProtectionManager.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_OnlyLoadDocumentProperties(true);

auto presentation = MakeObject<Presentation>(u"public-properties-encrypted.pptx", loadOptions);

if (presentation->get_ProtectionManager()->get_IsOnlyDocumentPropertiesLoaded())
{
    auto properties = presentation->get_DocumentProperties();

    Console::WriteLine(u"Author: " + properties->get_Author());
    Console::WriteLine(u"Title: " + properties->get_Title());
    Console::WriteLine(u"Keywords: " + properties->get_Keywords());
}
else
{
    Console::WriteLine(u"The presentation was not loaded in document-properties-only mode.");
}

presentation->Dispose();
```

In questa modalità, il contenuto delle diapositive non viene caricato. Diapositive, master, layout, forme, media e altri oggetti della presentazione non sono disponibili. Le applicazioni dovrebbero sempre controllare `get_IsOnlyDocumentPropertiesLoaded` prima di eseguire un'operazione che richiede il modello oggetto completo della presentazione.

{{% alert color="warning" title="Warning" %}}
I metadati pubblici possono esporre nomi degli autori, titoli, soggetti, parole chiave, informazioni aziendali, commenti e valori personalizzati. Cripta le proprietà sensibili insieme alla presentazione. Lasciale pubbliche solo quando sistemi di indicizzazione, classificazione, ricerca o gestione documenti hanno requisiti specifici per accedervi senza password.
{{% /alert %}}

## **Aggiornare le proprietà di una presentazione crittografata**

Per un file PPTX crittografato, una presentazione caricata dopo aver chiamato `set_OnlyLoadDocumentProperties(true)` è destinata alla lettura dei metadati pubblici. Aspose.Slides non può salvare le proprietà modificate da quell'oggetto a soli metadati perché le proprietà pubbliche devono rimanere coerenti con i dati corrispondenti all'interno della presentazione crittografata. Aggiornarle quindi richiede la password di apertura corretta e un caricamento completo.

Il seguente esempio apre la presentazione con [LoadOptions::set_Password](https://reference.aspose.com/slides/it/cpp/aspose.slides/loadoptions/set_password/), aggiorna le proprietà built-in pubbliche e salva il risultato. Quindi utilizza [IPresentationInfo::get_IsEncrypted](https://reference.aspose.com/slides/it/cpp/aspose.slides/ipresentationinfo/get_isencrypted/) per verificare che la crittografia sia preservata e riapre i metadati pubblici senza password per verificare i nuovi valori:

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IPresentationInfo.h>
#include <DOM/IProtectionManager.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <DOM/PresentationFactory.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

const String inputPath = u"public-properties-encrypted.pptx";
const String outputPath = u"updated-public-properties-encrypted.pptx";

{
    auto loadOptions = MakeObject<LoadOptions>();
    loadOptions->set_Password(u"open_password");

    auto presentation = MakeObject<Presentation>(inputPath, loadOptions);
    presentation->get_DocumentProperties()->set_Title(u"Updated Product Roadmap");
    presentation->get_DocumentProperties()->set_Keywords(u"roadmap, planning, indexed");
    presentation->Save(outputPath, SaveFormat::Pptx);
    presentation->Dispose();
}

auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(outputPath);
Console::WriteLine(presentationInfo->get_IsEncrypted() ? u"The presentation is encrypted." : u"The presentation is not encrypted.");

auto metadataLoadOptions = MakeObject<LoadOptions>();
metadataLoadOptions->set_OnlyLoadDocumentProperties(true);

auto metadataPresentation = MakeObject<Presentation>(outputPath, metadataLoadOptions);

if (metadataPresentation->get_ProtectionManager()->get_IsOnlyDocumentPropertiesLoaded())
{
    Console::WriteLine(u"Title: " + metadataPresentation->get_DocumentProperties()->get_Title());
    Console::WriteLine(u"Keywords: " + metadataPresentation->get_DocumentProperties()->get_Keywords());
}
else
{
    Console::WriteLine(u"The presentation was not loaded in document-properties-only mode.");
}

metadataPresentation->Dispose();
```

Se un'applicazione non è autorizzata a decrittare o caricare il contenuto della presentazione, deve trattare le proprietà pubbliche di un file PPTX crittografato come di sola lettura.

## **Accedere alle proprietà Built-in**

Queste proprietà esposte dall'oggetto **IDocumentProperties** includono: **Creator(Author)**, **Description**, **KeyWords**, **Created** (Data di creazione), **Modified** (Data di modifica), **Printed** (Data ultima stampa), **LastModifiedBy**, **Keywords**, **SharedDoc** (È condiviso tra diversi produttori?), **PresentationFormat**, **Subject** e **Title**.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessBuiltinProperties-AccessBuiltinProperties.cpp" >}}

## **Modificare le proprietà Built-in**

Modificare le proprietà built-in dei file di presentazione è semplice quanto accedervi. È sufficiente assegnare un valore stringa a qualsiasi proprietà desiderata e il valore della proprietà verrà modificato. Nell'esempio riportato di seguito, abbiamo dimostrato come modificare le proprietà documentali built-in del file di presentazione.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-UpdatePresentationProperties-UpdatePresentationProperties.cpp" >}}

## **Aggiungere proprietà personalizzate alla presentazione**

Aspose.Slides for C++ consente agli sviluppatori di aggiungere i valori custom per le proprietà del documento della presentazione. Di seguito è riportato un esempio che mostra come impostare le proprietà custom per una presentazione.

``` cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Istituziona la classe Presentation
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

Aspose.Slides for C++ consente inoltre agli sviluppatori di accedere ai valori delle proprietà custom. Di seguito è riportato un esempio che mostra come è possibile accedere e modificare tutte queste proprietà custom per una presentazione.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessModifyingProperties-AccessModifyingProperties.cpp" >}}

## **Impostare la lingua di correzione**

Aspose.Slides fornisce la proprietà [LanguageId](https://reference.aspose.com/slides/it/cpp/aspose.slides/baseportionformat/set_languageid/) (esposta dalla classe [PortionFormat](https://reference.aspose.com/slides/it/cpp/aspose.slides/portionformat/)) per consentire di impostare la lingua di correzione per un documento PowerPoint. La lingua di correzione è la lingua per la quale ortografia e grammatica in PowerPoint vengono controllate.

Questo codice C++ mostra come impostare la lingua di correzione per un PowerPoint:

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
// set the Id of a proofing language

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

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/it/metadata)

## **FAQ**

**Come posso rimuovere una proprietà built-in da una presentazione?**

Le proprietà built-in fanno parte integrante della presentazione e non possono essere rimosse completamente. Tuttavia, è possibile cambiarne i valori o impostarle a vuoto se la proprietà lo consente.

**Cosa succede se aggiungo una proprietà custom che esiste già?**

Se aggiungi una proprietà custom che esiste già, il suo valore corrente verrà sovrascritto con quello nuovo. Non è necessario rimuovere o controllare la proprietà in anticipo, poiché Aspose.Slides aggiorna automaticamente il valore della proprietà.

**Posso accedere alle proprietà della presentazione senza caricare completamente la presentazione?**

Sì. Usa [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/it/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) e poi [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/it/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) per leggere i metadati del documento memorizzati senza creare un'istanza di [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/). Vedi [Build a Lightweight Presentation Inventory](/slides/it/cpp/examine-presentation/) per un esempio completo di report e le limitazioni specifiche dei formati.

**Posso leggere le proprietà pubbliche di una presentazione crittografata senza la sua password di apertura?**

Sì. La presentazione deve essere stata crittografata passando `false` a `set_EncryptDocumentProperties`, e deve essere caricata passando `true` a `set_OnlyLoadDocumentProperties`.

**Posso aggiornare un file PPTX crittografato in modalità solo-proprietà-documento?**

No. I dati delle proprietà pubbliche e crittografate devono rimanere coerenti, quindi l'aggiornamento di un file PPTX crittografato richiede il caricamento completo della presentazione con la password di apertura corretta.