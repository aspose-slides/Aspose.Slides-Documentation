---
title: Esporta presentazioni in XAML con Python
linktitle: Esporta in XAML
type: docs
weight: 30
url: /it/python-net/export-to-xaml/
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
- Python
- Aspose.Slides
description: "Converti diapositive PowerPoint e OpenDocument in XAML con Python usando Aspose.Slides—soluzione veloce, senza Office, che mantiene intatto il layout."
---
## **Panoramica**

Questo articolo spiega come esportare presentazioni PowerPoint in XAML usando Aspose.Slides. Include una breve introduzione a XAML, mostra come salvare una presentazione in XAML con le impostazioni predefinite e dimostra come personalizzare l'esportazione tramite [XamlOptions](https://reference.aspose.com/slides/it/python-net/aspose.slides.export.xaml/xamloptions/), inclusa l'esportazione delle diapositive nascoste. L'articolo risponde anche a alcune domande comuni relative ai font di fallback, alla compatibilità con gli stack XAML e al comportamento dell'esportazione delle diapositive nascoste.

## **Informazioni su XAML**

XAML è un linguaggio di programmazione descrittivo che ti consente di creare o scrivere interfacce utente per le app, soprattutto quelle che utilizzano WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) e Xamarin Forms.  

XAML, che è un linguaggio basato su XML, è la variante di Microsoft per descrivere una GUI. È probabile che tu usi spesso un designer per lavorare sui file XAML, ma puoi comunque scrivere e modificare la tua GUI. 

## **Esporta presentazioni in XAML con opzioni predefinite**

Questo codice Python mostra come esportare una presentazione in XAML con le impostazioni predefinite:

```py
import aspose.slides as slides

pres = slides.Presentation("pres.pptx")
pres.save(slides.export.xaml.XamlOptions())
```

## **Esporta presentazioni in XAML con opzioni personalizzate**

Puoi selezionare le opzioni dalla classe [XamlOptions](https://reference.aspose.com/slides/it/python-net/aspose.slides.export.xaml/xamloptions/) che controllano il processo di esportazione e determinano come Aspose.Slides esporta la tua presentazione in XAML. 

Ad esempio, se desideri che Aspose.Slides aggiunga le diapositive nascoste dalla tua presentazione durante l'esportazione in XAML, puoi impostare la proprietà [export_hidden_slides](https://reference.aspose.com/slides/it/python-net/aspose.slides.export.xaml/xamloptions/export_hidden_slides/) su `True`. Vedi questo esempio di codice Python: 

```py
import aspose.slides as slides

pres = slides.Presentation("pres.pptx")

opt = slides.export.xaml.XamlOptions()
opt.export_hidden_slides = True

pres.save(opt)
```

## **FAQ**

**Come posso garantire caratteri prevedibili se il font originale non è disponibile sul computer?**

Imposta [default_regular_font](https://reference.aspose.com/slides/it/python-net/aspose.slides.export.xaml/xamloptions/default_regular_font/) in [XamlOptions](https://reference.aspose.com/slides/it/python-net/aspose.slides.export.xaml/xamloptions/) — viene usato come font di fallback quando quello originale è mancante. Questo aiuta a evitare sostituzioni inaspettate.

**L'XAML esportato è destinato solo a WPF o può essere usato anche in altri stack XAML?**

XAML è un linguaggio di markup UI generale utilizzato in WPF, UWP e Xamarin.Forms. L'esportazione mira alla compatibilità con gli stack XAML di Microsoft; il comportamento esatto e il supporto per costrutti specifici dipendono dalla piattaforma di destinazione. Prova il markup nel tuo ambiente.

**Le diapositive nascoste sono supportate e come posso impedire che vengano esportate per impostazione predefinita?**

Per impostazione predefinita, le diapositive nascoste non sono incluse. Puoi controllare questo comportamento tramite [export_hidden_slides](https://reference.aspose.com/slides/it/python-net/aspose.slides.export.xaml/xamloptions/export_hidden_slides/) in [XamlOptions](https://reference.aspose.com/slides/it/python-net/aspose.slides.export.xaml/xamloptions/) — mantienila disabilitata se non hai bisogno di esportarle.