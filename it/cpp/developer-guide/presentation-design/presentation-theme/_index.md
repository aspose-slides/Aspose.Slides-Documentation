---
title: Gestire i temi delle presentazioni in C++
linktitle: Tema della presentazione
type: docs
weight: 10
url: /it/cpp/presentation-theme/
keywords:
- Tema PowerPoint
- Tema della presentazione
- Tema della diapositiva
- Imposta tema
- Cambia tema
- Gestisci tema
- Colore del tema
- Tavolozza aggiuntiva
- Carattere del tema
- Stile del tema
- Effetto del tema
- PowerPoint
- OpenDocument
- presentazione
- C++
- Aspose.Slides
description: "Gestisci i temi principali delle presentazioni in Aspose.Slides per C++ per creare, personalizzare e convertire file PowerPoint con un branding coerente."
---
## **Introduzione**

Un tema di presentazione definisce un insieme coordinato di colori, caratteri, stili di sfondo, riempimenti, linee ed effetti. Gli oggetti sensibili al tema fanno riferimento a queste definizioni condivise invece di memorizzare ogni proprietà visiva come valore fisso, così una modifica al tema può aggiornare molti oggetti contemporaneamente.

In Aspose.Slides, il tema a livello di presentazione è disponibile tramite [Presentation::get_MasterTheme()](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/get_mastertheme/). Una presentazione può inoltre contenere overriding del tema a livelli inferiori. Un master può sovrascrivere il tema della presentazione tramite [MasterThemeManager::get_OverrideTheme()](https://reference.aspose.com/slides/it/cpp/aspose.slides.theme/masterthememanager/get_overridetheme/), mentre un layout o una diapositiva individuale può utilizzare [IOverrideThemeManager::get_OverrideTheme()](https://reference.aspose.com/slides/it/cpp/aspose.slides.theme/ioverridethememanager/get_overridetheme/). In pratica, il tema effettivo per una diapositiva è risolto tramite questa catena di ereditarietà: tema della presentazione, override del master, override del layout e override della diapositiva.

![Componenti del tema: colori, caratteri, stili di sfondo ed effetti](theme-constituents.png)

Le sezioni seguenti mostrano i flussi di lavoro più comuni sul tema: esaminare un tema, modificare colori e caratteri, copiare o applicare un tema, aggiornare gli stili di sfondo ed effetti, e leggere i valori effettivi dopo che ereditarietà e override sono stati risolti.

## **Esaminare un tema**

L'oggetto [MasterTheme](https://reference.aspose.com/slides/it/cpp/aspose.slides.theme/mastertheme/) espone i metodi del tema [get_ColorScheme()](https://reference.aspose.com/slides/it/cpp/aspose.slides.theme/mastertheme/get_colorscheme/), [get_FontScheme()](https://reference.aspose.com/slides/it/cpp/aspose.slides.theme/mastertheme/get_fontscheme/) e [get_FormatScheme()](https://reference.aspose.com/slides/it/cpp/aspose.slides.theme/mastertheme/get_formatscheme/). Esaminare queste collezioni prima di modificarle è particolarmente utile quando una presentazione proviene da una fonte esterna, poiché il numero e il contenuto delle voci di stile possono variare.

L'esempio seguente legge le proprietà principali del tema e riporta quante voci di stile di sfondo, riempimento, linea ed effetto sono memorizzate nel tema:

```cpp
#include <DOM/IColorFormat.h>
#include <DOM/IFonts.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IColorScheme.h>
#include <DOM/Theme/IEffectStyleCollection.h>
#include <DOM/Theme/IFillFormatCollection.h>
#include <DOM/Theme/IFontScheme.h>
#include <DOM/Theme/IFormatScheme.h>
#include <DOM/Theme/ILineFormatCollection.h>
#include <DOM/Theme/IMasterTheme.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto theme = presentation->get_MasterTheme();
auto formatScheme = theme->get_FormatScheme();

Console::WriteLine(u"Theme name: {0}", theme->get_Name());
Console::WriteLine(u"Accent 1: {0}", theme->get_ColorScheme()->get_Accent1()->get_Color());
Console::WriteLine(u"Major Latin font: {0}", theme->get_FontScheme()->get_Major()->get_LatinFont()->get_FontName());
Console::WriteLine(u"Minor Latin font: {0}", theme->get_FontScheme()->get_Minor()->get_LatinFont()->get_FontName());
Console::WriteLine(u"Background fill styles: {0}", formatScheme->get_BackgroundFillStyles()->get_Count());
Console::WriteLine(u"Fill styles: {0}", formatScheme->get_FillStyles()->get_Count());
Console::WriteLine(u"Line styles: {0}", formatScheme->get_LineStyles()->get_Count());
Console::WriteLine(u"Effect styles: {0}", formatScheme->get_EffectStyles()->get_Count());
```

Se un file utilizza più master, non dare per scontato che ogni diapositiva abbia lo stesso tema effettivo. Esamina il master associato alla diapositiva e utilizza il flusso di lavoro tema‑effettivo mostrato più avanti in questo articolo quando potrebbero essere presenti override di layout o di diapositiva.

## **Modificare i colori del tema**

I riempimenti, le linee e il testo sensibili al tema possono fare riferimento a un colore logico dall'enumerazione [SchemeColor](https://reference.aspose.com/slides/it/cpp/aspose.slides/schemecolor/). Quando cambi la voce corrispondente nello [IColorScheme](https://reference.aspose.com/slides/it/cpp/aspose.slides.theme/icolorscheme/) del tema, tutti gli oggetti che ancora fanno riferimento a quel colore del tema sono risolti rispetto al nuovo valore. Gli oggetti che utilizzano un colore RGB diretto non sono modificati da un aggiornamento del colore del tema.

L'esempio end‑to‑end seguente crea una forma che utilizza `Accent4`, cambia il colore `Accent4` del tema in rosso, salva la presentazione, la riapre e stampa il colore di riempimento effettivo:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IFillFormatEffectiveData.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/SchemeColor.h>
#include <DOM/ShapeType.h>
#include <DOM/Theme/IColorScheme.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);
presentation->get_MasterTheme()->get_ColorScheme()->get_Accent4()->set_Color(Color::get_Red());
presentation->Save(u"theme-color.pptx", SaveFormat::Pptx);

auto savedPresentation = MakeObject<Presentation>(u"theme-color.pptx");
auto savedSlide = savedPresentation->get_Slide(0);
auto savedShape = savedSlide->get_Shape(0);
auto effectiveFill = savedShape->get_FillFormat()->GetEffective();
Console::WriteLine(u"Effective fill color: {0}", effectiveFill->get_SolidFillColor());
```

Poiché il rettangolo rimane collegato a `Accent4`, il suo colore visibile diventa rosso dopo la modifica del tema. Se sostituisci il colore della tavolozza con un colore diretto sulla forma, le modifiche successive a `Accent4` non influenzeranno più quel riempimento.

### **Usare i colori dalla tavolozza aggiuntiva**

PowerPoint genera varianti più chiare e più scure da un colore del tema applicando trasformazioni di colore. Aspose.Slides espone queste trasformazioni tramite [ColorTransformOperation](https://reference.aspose.com/slides/it/cpp/aspose.slides/colortransformoperation/).

![Colori principali del tema e colori più chiari e più scuri generati dalla tavolozza aggiuntiva](additional-palette-colors.png)

**1** - Colori principali del tema.

**2** - Varianti più chiare e più scure generate dai colori principali del tema.

L'esempio seguente crea sei rettangoli basati su `Accent4`, applica trasformazioni di luminanza a cinque di essi e salva il risultato:

```cpp
#include <DOM/ColorTransformOperation.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IColorOperationCollection.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/SchemeColor.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto shapes = presentation->get_Slide(0)->get_Shapes();

auto shape1 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 50.0f, 50.0f);
auto fillFormat1 = shape1->get_FillFormat();
fillFormat1->set_FillType(FillType::Solid);
fillFormat1->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);

auto shape2 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 70.0f, 50.0f, 50.0f);
auto fillFormat2 = shape2->get_FillFormat();
auto solidFillColor2 = fillFormat2->get_SolidFillColor();
fillFormat2->set_FillType(FillType::Solid);
solidFillColor2->set_SchemeColor(SchemeColor::Accent4);
solidFillColor2->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.2f);
solidFillColor2->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.8f);

auto shape3 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 130.0f, 50.0f, 50.0f);
auto fillFormat3 = shape3->get_FillFormat();
auto solidFillColor3 = fillFormat3->get_SolidFillColor();
fillFormat3->set_FillType(FillType::Solid);
solidFillColor3->set_SchemeColor(SchemeColor::Accent4);
solidFillColor3->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.4f);
solidFillColor3->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.6f);

auto shape4 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 190.0f, 50.0f, 50.0f);
auto fillFormat4 = shape4->get_FillFormat();
auto solidFillColor4 = fillFormat4->get_SolidFillColor();
fillFormat4->set_FillType(FillType::Solid);
solidFillColor4->set_SchemeColor(SchemeColor::Accent4);
solidFillColor4->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.6f);
solidFillColor4->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.4f);

auto shape5 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 250.0f, 50.0f, 50.0f);
auto fillFormat5 = shape5->get_FillFormat();
auto solidFillColor5 = fillFormat5->get_SolidFillColor();
fillFormat5->set_FillType(FillType::Solid);
solidFillColor5->set_SchemeColor(SchemeColor::Accent4);
solidFillColor5->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.75f);

auto shape6 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 310.0f, 50.0f, 50.0f);
auto fillFormat6 = shape6->get_FillFormat();
auto solidFillColor6 = fillFormat6->get_SolidFillColor();
fillFormat6->set_FillType(FillType::Solid);
solidFillColor6->set_SchemeColor(SchemeColor::Accent4);
solidFillColor6->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.5f);

presentation->Save(u"theme-color-palette.pptx", SaveFormat::Pptx);
```

Queste varianti rimangono basate sul colore del tema. Se `Accent4` cambia in seguito, i colori trasformati vengono ricalcolati dal nuovo valore `Accent4`.

### **Mappare i valori `SchemeColor` agli slot `IColorScheme`**

L'enumerazione [SchemeColor](https://reference.aspose.com/slides/it/cpp/aspose.slides/schemecolor/) utilizza `Text1`, `Background1`, `Text2` e `Background2`, mentre [IColorScheme](https://reference.aspose.com/slides/it/cpp/aspose.slides.theme/icolorscheme/) espone gli stessi slot del tema come `Dark1`, `Light1`, `Dark2` e `Light2`. La mappatura è fissa:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Questi sono nomi alternativi per gli stessi slot del tema; non sono valori convertiti dinamicamente da una forma all'altra.

## **Modificare i caratteri del tema**

Uno schema di caratteri del tema contiene un set di caratteri principali per le intestazioni e un set di caratteri secondari per il corpo del testo. I metodi [FontScheme::get_Major()](https://reference.aspose.com/slides/it/cpp/aspose.slides.theme/fontscheme/get_major/) e [FontScheme::get_Minor()](https://reference.aspose.com/slides/it/cpp/aspose.slides.theme/fontscheme/get_minor/) espongono tali set.

Gli identificatori di carattere del tema compatibili con PowerPoint possono essere usati nella formattazione del testo:

* `+mn‑lt` - Carattere corpo Latin (Minor Latin Font)
* `+mj‑lt` - Carattere intestazione Latin (Major Latin Font)
* `+mn‑ea` - Carattere corpo East Asian (Minor East Asian Font)
* `+mj‑ea` - Carattere intestazione East Asian (Major East Asian Font)

L'esempio seguente crea un'intestazione che utilizza il carattere Latin principale del tema e una riga di corpo che utilizza il carattere Latin secondario del tema. Quindi modifica i caratteri del tema e salva il risultato:

```cpp
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFonts.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/Theme/IFontScheme.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto heading = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40.0f, 40.0f, 500.0f, 60.0f);
heading->get_TextFrame()->set_Text(u"Theme heading");
heading->get_TextFrame()->get_Paragraph(0)->get_Portion(0)->get_PortionFormat()->set_LatinFont(MakeObject<FontData>(u"+mj-lt"));

auto body = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40.0f, 120.0f, 500.0f, 60.0f);
body->get_TextFrame()->set_Text(u"Theme body text");
body->get_TextFrame()->get_Paragraph(0)->get_Portion(0)->get_PortionFormat()->set_LatinFont(MakeObject<FontData>(u"+mn-lt"));

presentation->get_MasterTheme()->get_FontScheme()->get_Major()->set_LatinFont(MakeObject<FontData>(u"Aptos Display"));
presentation->get_MasterTheme()->get_FontScheme()->get_Minor()->set_LatinFont(MakeObject<FontData>(u"Arial"));
presentation->Save(u"theme-fonts.pptx", SaveFormat::Pptx);
```

L'intestazione segue il carattere principale e il testo del corpo segue quello secondario. Il testo che ha un nome di carattere esplicito invece di un identificatore del tema non cambierà automaticamente quando lo schema di caratteri del tema verrà modificato.

{{% alert color="info" title="Tip" %}}
Per ulteriori informazioni sui caratteri delle presentazioni, vedere [PowerPoint Fonts](/slides/it/cpp/powerpoint-fonts/).
{{% /alert %}}

## **Copiare o applicare un tema**

Esistono due flussi di lavoro comuni, e risolvono problemi diversi.

### **Conservare un tema sorgente durante lo spostamento delle diapositive**

Se vuoi spostare una diapositiva in un'altra presentazione e conservare il design originale, clona il master sorgente nella presentazione di destinazione con [IMasterSlideCollection::AddClone()](https://reference.aspose.com/slides/it/cpp/aspose.slides/imasterslidecollection/addclone/), quindi clona la diapositiva con [ISlideCollection::AddClone()](https://reference.aspose.com/slides/it/cpp/aspose.slides/islidecollection/addclone/) e il master clonato. Questo porta con sé il master, i suoi layout e il tema associato.

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IMasterSlideCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto source = MakeObject<Presentation>(u"source-theme.pptx");
auto target = MakeObject<Presentation>(u"target.pptx");
auto sourceSlide = source->get_Slide(0);
auto sourceMaster = sourceSlide->get_LayoutSlide()->get_MasterSlide();
auto clonedMaster = target->get_Masters()->AddClone(sourceMaster);
target->get_Slides()->AddClone(sourceSlide, clonedMaster, true);
target->Save(u"theme-preserved.pptx", SaveFormat::Pptx);
```

Questo è il flusso di lavoro preferito quando la diapositiva sorgente deve apparire identica nella destinazione. Clonare semplicemente il contenuto su un master di destinazione non correlato può modificare i colori, i caratteri, gli sfondi e gli effetti guidati dal tema.

### **Applicare i valori del tema a una diapositiva esistente**

Se la diapositiva di destinazione deve rimanere sul suo master e layout attuali, inizializza un override a livello di diapositiva dal tema sorgente. I metodi [OverrideTheme::InitColorSchemeFrom()](https://reference.aspose.com/slides/it/cpp/aspose.slides.theme/overridetheme/initcolorschemefrom/), [OverrideTheme::InitFontSchemeFrom()](https://reference.aspose.com/slides/it/cpp/aspose.slides.theme/overridetheme/initfontschemefrom/) e [OverrideTheme::InitFormatSchemeFrom()](https://reference.aspose.com/slides/it/cpp/aspose.slides.theme/overridetheme/initformatschemefrom/) copiano i tre componenti principali del tema nell'override.

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IOverrideTheme.h>
#include <DOM/Theme/IOverrideThemeManager.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto source = MakeObject<Presentation>(u"source-theme.pptx");
auto target = MakeObject<Presentation>(u"target.pptx");
auto targetSlide = target->get_Slide(0);
auto overrideTheme = targetSlide->get_ThemeManager()->get_OverrideTheme();
overrideTheme->InitColorSchemeFrom(source->get_MasterTheme()->get_ColorScheme());
overrideTheme->InitFontSchemeFrom(source->get_MasterTheme()->get_FontScheme());
overrideTheme->InitFormatSchemeFrom(source->get_MasterTheme()->get_FormatScheme());
target->Save(u"theme-applied-to-slide.pptx", SaveFormat::Pptx);
```

Questo modifica il tema utilizzato da quella diapositiva senza cambiare il tema ereditato dalle altre diapositive. Per rimuovere l'override locale e tornare ai valori ereditati, chiama [OverrideTheme::Clear()](https://reference.aspose.com/slides/it/cpp/aspose.slides.theme/overridetheme/clear/).

### **Applicare un override del tema a un layout**

Un override a livello di layout si applica alle diapositive che usano quel layout, a meno che una particolare diapositiva non abbia il proprio override. Gli stessi metodi di inizializzazione possono essere usati tramite l'[IOverrideThemeManager](https://reference.aspose.com/slides/it/cpp/aspose.slides.theme/ioverridethememanager/) del layout:

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IOverrideTheme.h>
#include <DOM/Theme/IOverrideThemeManager.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto source = MakeObject<Presentation>(u"source-theme.pptx");
auto target = MakeObject<Presentation>(u"target.pptx");
auto targetSlide = target->get_Slide(0);
auto targetLayout = targetSlide->get_LayoutSlide();
auto overrideTheme = targetLayout->get_ThemeManager()->get_OverrideTheme();
overrideTheme->InitColorSchemeFrom(source->get_MasterTheme()->get_ColorScheme());
overrideTheme->InitFontSchemeFrom(source->get_MasterTheme()->get_FontScheme());
overrideTheme->InitFormatSchemeFrom(source->get_MasterTheme()->get_FormatScheme());
target->Save(u"theme-applied-to-layout.pptx", SaveFormat::Pptx);
```

Usa un tema a livello di master o di presentazione quando molti layout e diapositive devono condividere lo stesso design di base, un override di layout quando una famiglia di layout necessita di uno styling diverso, e un override di diapositiva solo per eccezioni reali. Troppi override a livello di diapositiva rendono più difficile prevedere le modifiche globali del tema in seguito.

## **Aggiornare gli stili di sfondo del tema**

I riempimenti di sfondo del tema sono memorizzati in [FormatScheme::get_BackgroundFillStyles()](https://reference.aspose.com/slides/it/cpp/aspose.slides.theme/formatscheme/get_backgroundfillstyles/). PowerPoint può presentare più scelte di sfondo nella sua UI rispetto al numero di definizioni di riempimento fisicamente memorizzate in questa collezione, perché la UI può combinare riempimenti del tema con colori del tema e altri riferimenti di stile.

![Galleria di stili di sfondo di PowerPoint per un tema di presentazione](presentation-design_8.png)

Prima di usare uno stile di sfondo, ispeziona la collezione memorizzata e l'attuale [Background::get_StyleIndex()](https://reference.aspose.com/slides/it/cpp/aspose.slides/background/get_styleindex/). `StyleIndex` usa `0` per nessun riempimento tematico; i valori positivi sono riferimenti a stili di sfondo tematici. Questo è diverso dall'indicizzare una collezione C++ direttamente con `idx_get(0)`, dove `0` indica il primo elemento memorizzato. Non dare per scontato che ogni presentazione contenga lo stesso numero di stili di riempimento di sfondo.

L'esempio seguente riporta il conteggio dei riempimenti di sfondo disponibili, assegna un riferimento di sfondo tematico al primo master e salva la presentazione:

```cpp
#include <DOM/BackgroundType.h>
#include <DOM/IBackground.h>
#include <DOM/IMasterSlide.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IFillFormatCollection.h>
#include <DOM/Theme/IFormatScheme.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto backgroundStyles = presentation->get_MasterTheme()->get_FormatScheme()->get_BackgroundFillStyles();
Console::WriteLine(u"Background fill styles: {0}", backgroundStyles->get_Count());

if (backgroundStyles->get_Count() > 0)
{
    auto masterSlide = presentation->get_Master(0);
    masterSlide->get_Background()->set_Type(BackgroundType::Themed);
    masterSlide->get_Background()->set_StyleIndex(1);
    presentation->Save(u"theme-background.pptx", SaveFormat::Pptx);
}
```

Il risultato visibile dipende dall'ingresso del tema a cui fa riferimento il master e da eventuali override di sfondo a livello di layout o diapositiva. Se una diapositiva utilizza il proprio sfondo, modificare solo lo sfondo del master potrebbe non influenzare quella diapositiva. Usa [Background::GetEffective()](https://reference.aspose.com/slides/it/cpp/aspose.slides/background/geteffective/) quando devi conoscere lo sfondo finale dopo l'applicazione dell'ereditarietà.

{{% alert color="warning" title="Warning" %}}
Non trattare `StyleIndex` come un indice di collezione basato su zero. Evita inoltre di codificare un numero di stile da un file e di supporre che abbia la stessa apparenza in un altro file; le definizioni di stile del tema sono specifiche della presentazione.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Per la formattazione diretta dello sfondo e l'ereditarietà dello sfondo, vedere [Presentation Background](/slides/it/cpp/presentation-background/).
{{% /alert %}}

## **Aggiornare gli effetti del tema**

Uno schema di formato del tema contiene collezioni separate per [FormatScheme::get_FillStyles()](https://reference.aspose.com/slides/it/cpp/aspose.slides.theme/formatscheme/get_fillstyles/), [FormatScheme::get_LineStyles()](https://reference.aspose.com/slides/it/cpp/aspose.slides.theme/formatscheme/get_linestyles/) e [FormatScheme::get_EffectStyles()](https://reference.aspose.com/slides/it/cpp/aspose.slides.theme/formatscheme/get_effectstyles/). I temi tipici di Office spesso includono tre voci di stile principali che corrispondono visivamente a formattazioni sottili, moderate e intense, ma il codice dovrebbe ispezionare ogni collezione invece di presumere un conteggio fisso.

![Effetti del tema sottili, moderati e intensi applicati alla stessa forma](presentation-design_10.png)

Quando accedi a queste collezioni in C++, l'indice della collezione è basato su zero: `idx_get(0)` è il primo stile memorizzato e `idx_get(2)` è il terzo. Gli indici di riferimento di stile di una forma sono un concetto separato, esposto tramite [IShapeStyle](https://reference.aspose.com/slides/it/cpp/aspose.slides/ishapestyle/). Modificare uno stile del tema influisce sulle forme che fanno riferimento a quello stile; le forme con formattazione diretta possono rimanere invariate.

L'esempio seguente controlla che le voci di stile richieste esistano, modifica il primo stile di linea, modifica il terzo stile di riempimento, abilita un'ombra esterna nel terzo stile di effetto e salva il risultato:

```cpp
#include <DOM/Effects/IOuterShadow.h>
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IEffectStyle.h>
#include <DOM/Theme/IEffectStyleCollection.h>
#include <DOM/Theme/IFillFormatCollection.h>
#include <DOM/Theme/IFormatScheme.h>
#include <DOM/Theme/ILineFormatCollection.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"Subtle_Moderate_Intense.pptx");
auto formatScheme = presentation->get_MasterTheme()->get_FormatScheme();
auto lineStyles = formatScheme->get_LineStyles();
auto fillStyles = formatScheme->get_FillStyles();
auto effectStyles = formatScheme->get_EffectStyles();

if (lineStyles->get_Count() < 1 || fillStyles->get_Count() < 3 || effectStyles->get_Count() < 3)
{
    Console::WriteLine(u"The theme does not contain the style entries required by this example.");
}
else
{
    auto lineStyle = lineStyles->idx_get(0);
    lineStyle->get_FillFormat()->set_FillType(FillType::Solid);
    lineStyle->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());

    auto fillStyle = fillStyles->idx_get(2);
    fillStyle->set_FillType(FillType::Solid);
    fillStyle->get_SolidFillColor()->set_Color(Color::get_ForestGreen());

    auto effectFormat = effectStyles->idx_get(2)->get_EffectFormat();
    effectFormat->EnableOuterShadowEffect();
    effectFormat->get_OuterShadowEffect()->set_Distance(10.0f);

    presentation->Save(u"theme-effects.pptx", SaveFormat::Pptx);
}
```

Per le forme che fanno riferimento a questi slot, il primo stile di linea del tema diventa rosso, il terzo stile di riempimento del tema diventa verde foresta solido e il terzo stile di effetto ottiene un'ombra esterna con una distanza di 10 punti. Il risultato visivo esatto dipende comunque da quali slot di stile ogni forma riferisce e se la formattazione diretta sovrascrive il tema.

![Stili di effetto del tema dopo aver modificato le impostazioni di linea, riempimento e ombra](presentation-design_11.png)

## **Leggere i valori effettivi del tema**

Gli oggetti grezzi del tema indicano cosa è definito a un livello particolare. I valori effettivi indicano cosa una diapositiva o una forma utilizza realmente dopo che ereditarietà e override locali sono stati risolti. Per una diapositiva, chiama [IThemeable::CreateThemeEffective()](https://reference.aspose.com/slides/it/cpp/aspose.slides.theme/ithemeable/createthemeeffective/). Per uno sfondo, usa [Background::GetEffective()](https://reference.aspose.com/slides/it/cpp/aspose.slides/background/geteffective/), e per un riempimento, usa [FillFormat::GetEffective()](https://reference.aspose.com/slides/it/cpp/aspose.slides/fillformat/geteffective/).

L'esempio seguente legge il tema effettivo, lo sfondo e il primo riempimento della forma da una diapositiva:

```cpp
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IBackgroundEffectiveData.h>
#include <DOM/IFillFormat.h>
#include <DOM/IFillFormatEffectiveData.h>
#include <DOM/IFontsEffectiveData.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IFontSchemeEffectiveData.h>
#include <DOM/Theme/IThemeEffectiveData.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto slide = presentation->get_Slide(0);
auto effectiveTheme = slide->CreateThemeEffective();
auto effectiveBackground = slide->get_Background()->GetEffective();

Console::WriteLine(u"Effective major Latin font: {0}", effectiveTheme->get_FontScheme()->get_Major()->get_LatinFont()->get_FontName());
Console::WriteLine(u"Effective minor Latin font: {0}", effectiveTheme->get_FontScheme()->get_Minor()->get_LatinFont()->get_FontName());
Console::WriteLine(u"Effective background fill type: {0}", effectiveBackground->get_FillFormat()->get_FillType());

if (slide->get_Shapes()->get_Count() > 0)
{
    auto effectiveFill = slide->get_Shape(0)->get_FillFormat()->GetEffective();
    Console::WriteLine(u"First shape effective fill type: {0}", effectiveFill->get_FillType());
    if (effectiveFill->get_FillType() == FillType::Solid)
    {
        Console::WriteLine(u"First shape effective fill color: {0}", effectiveFill->get_SolidFillColor());
    }
}
```

Usa i dati effettivi per diagnostica di rendering, convalida e confronti. Se esamini solo [Presentation::get_MasterTheme()](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/get_mastertheme/), potresti perdere un master, layout, diapositiva o override di forma che cambia l'aspetto finale.

## **FAQ**

**Posso applicare un tema a una singola diapositiva senza cambiare il master?**

Sì. Usa l'[IOverrideThemeManager](https://reference.aspose.com/slides/it/cpp/aspose.slides.theme/ioverridethememanager/) della diapositiva e inizializza il suo tema di override. La modifica rimane locale a quella diapositiva; le altre diapositive continuano a ereditare i loro temi esistenti.

**Qual è il modo più sicuro per trasferire un tema da una presentazione all'altra?**

Quando sposti una diapositiva e conservi l'aspetto originale, clona il master sorgente nella destinazione e clona la diapositiva con quel master usando [IMasterSlideCollection::AddClone()](https://reference.aspose.com/slides/it/cpp/aspose.slides/imasterslidecollection/addclone/) e [ISlideCollection::AddClone()](https://reference.aspose.com/slides/it/cpp/aspose.slides/islidecollection/addclone/). Questo mantiene insieme il master, i layout e il tema.

**Come posso vedere i valori effettivi dopo l'ereditarietà e gli override?**

Usa [IThemeable::CreateThemeEffective()](https://reference.aspose.com/slides/it/cpp/aspose.slides.theme/ithemeable/createthemeeffective/) per una diapositiva o tema di layout e i metodi corrispondenti per i dati effettivi di oggetti di formato come [Background::GetEffective()](https://reference.aspose.com/slides/it/cpp/aspose.slides/background/geteffective/) e [FillFormat::GetEffective()](https://reference.aspose.com/slides/it/cpp/aspose.slides/fillformat/geteffective/). Queste API restituiscono i valori risolti dopo l'applicazione di ereditarietà e override.