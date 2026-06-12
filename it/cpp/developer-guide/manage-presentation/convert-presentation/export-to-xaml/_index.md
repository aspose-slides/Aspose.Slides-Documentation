---
title: Esporta presentazioni in XAML con C++
linktitle: Presentazione in XAML
type: docs
weight: 30
url: /it/cpp/export-to-xaml/
keywords:
- esporta PowerPoint
- esporta OpenDocument
- esporta presentazione
- converti PowerPoint
- converti OpenDocument
- converti presentazione
- PowerPoint in XAML
- OpenDocument in XAML
- presentazione in XAML
- PPT in XAML
- PPTX in XAML
- ODP in XAML
- salva PPT come XAML
- salva PPTX come XAML
- salva ODP come XAML
- esporta PPT in XAML
- esporta PPTX in XAML
- esporta ODP in XAML
- C++
- Aspose.Slides
description: "Converti le diapositive PowerPoint e OpenDocument in XAML con C++ usando Aspose.Slides—soluzione rapida, senza Office, che mantiene intatto il layout."
---
## **Panoramica**

Questo articolo spiega come esportare le presentazioni PowerPoint in XAML utilizzando Aspose.Slides. Include una breve introduzione a XAML, mostra come salvare una presentazione in XAML con le impostazioni predefinite e dimostra come personalizzare l'esportazione tramite [XamlOptions](https://reference.aspose.com/slides/it/cpp/aspose.slides.export.xaml/xamloptions/), includendo l'esportazione delle diapositive nascoste. L'articolo risponde anche a alcune domande frequenti relative ai caratteri di fallback, alla compatibilità con gli stack XAML e al comportamento dell'esportazione delle diapositive nascoste.

## **Informazioni su XAML**

XAML è un linguaggio di programmazione descrittivo che consente di creare o scrivere interfacce utente per app, in particolare per quelle che utilizzano WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) e Xamarin Forms.  

XAML, che è un linguaggio basato su XML, è la variante Microsoft per descrivere un'interfaccia grafica. Probabilmente utilizzerai un designer per lavorare sui file XAML nella maggior parte dei casi, ma puoi comunque scrivere e modificare la tua interfaccia.

## **Esporta presentazioni in XAML con opzioni predefinite**

Questo codice C++ mostra come esportare una presentazione in XAML con le impostazioni predefinite:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(System::MakeObject<XamlOptions>());
```

## **Esporta presentazioni in XAML con opzioni personalizzate**

Puoi selezionare le opzioni dall'interfaccia [IXamlOptions](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.export.xaml.i_xaml_options) che controllano il processo di esportazione e determinano come Aspose.Slides esporta la tua presentazione in XAML.  

Ad esempio, se desideri che Aspose.Slides aggiunga le diapositive nascoste dalla tua presentazione durante l'esportazione in XAML, puoi passare true al metodo [set_ExportHiddenSlides()](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.export.xaml.i_xaml_options#a94c59a06cc2163b17e6fa2fe817c0313). Vedi questo esempio di codice C++:

``` cpp
auto xamlOptions = System::MakeObject<XamlOptions>();
xamlOptions->set_ExportHiddenSlides(true);

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(xamlOptions);
```

## **FAQ**

**Come posso garantire font prevedibili se il font originale non è disponibile sul computer?**

Usa [set_DefaultRegularFont](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/saveoptions/set_defaultregularfont/) in [XamlOptions](https://reference.aspose.com/slides/it/cpp/aspose.slides.export.xaml/xamloptions/) — viene utilizzato come font di fallback quando quello originale è mancante. Questo aiuta a evitare sostituzioni inattese.

**L'XAML esportato è destinato solo a WPF o può essere utilizzato anche in altri stack XAML?**

XAML è un linguaggio di markup UI generale utilizzato in WPF, UWP e Xamarin.Forms. L'esportazione mira alla compatibilità con gli stack XAML di Microsoft; il comportamento esatto e il supporto per costrutti specifici dipendono dalla piattaforma di destinazione. Prova il markup nel tuo ambiente.

**Le diapositive nascoste sono supportate e come posso impedire che vengano esportate per impostazione predefinita?**

Per impostazione predefinita, le diapositive nascoste non sono incluse. Puoi controllare questo comportamento tramite [set_ExportHiddenSlides](https://reference.aspose.com/slides/it/cpp/aspose.slides.export.xaml/xamloptions/set_exporthiddenslides/) in [XamlOptions](https://reference.aspose.com/slides/it/cpp/aspose.slides.export.xaml/xamloptions/) — mantienilo disabilitato se non è necessario esportarle.