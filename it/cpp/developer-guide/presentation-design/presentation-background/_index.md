---
title: Gestire gli sfondi della presentazione in C++
linktitle: Sfondo diapositiva
type: docs
weight: 20
url: /it/cpp/presentation-background/
keywords:
- sfondo presentazione
- sfondo diapositiva
- colore solido
- colore a gradiente
- sfondo immagine
- trasparenza sfondo
- proprietà sfondo
- PowerPoint
- OpenDocument
- presentazione
- C++
- Aspose.Slides
description: "Scopri come impostare sfondi dinamici nei file PowerPoint e OpenDocument usando Aspose.Slides per C++, con suggerimenti di codice per migliorare le tue presentazioni."
---
## **Introduzione**

I colori solidi, le sfumature e le immagini sono comunemente usati per gli sfondi delle diapositive. È possibile impostare lo sfondo per una **diapositiva normale** (una singola diapositiva) o per una **diapositiva master** (si applica a più diapositive simultaneamente).

![Sfondo PowerPoint](powerpoint-background.png)

## **Imposta uno sfondo a tinta unita per una diapositiva normale**

Aspose.Slides consente di impostare un colore solido come sfondo per una diapositiva specifica in una presentazione, anche se la presentazione utilizza una diapositiva master. La modifica si applica solo alla diapositiva selezionata.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/).
2. Imposta il [BackgroundType](https://reference.aspose.com/slides/it/cpp/aspose.slides/backgroundtype/) della diapositiva su `OwnBackground`.
3. Imposta il [FillType](https://reference.aspose.com/slides/it/cpp/aspose.slides/filltype/) dello sfondo della diapositiva su `Solid`.
4. Usa il metodo [get_SolidFillColor](https://reference.aspose.com/slides/it/cpp/aspose.slides/fillformat/get_solidfillcolor/) su [FillFormat](https://reference.aspose.com/slides/it/cpp/aspose.slides/fillformat/) per specificare il colore di sfondo solido.
5. Salva la presentazione modificata.

Il seguente esempio C++ mostra come impostare un colore solido blu come sfondo per una diapositiva normale:

```cpp
// Crea un'istanza della classe Presentation.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

// Imposta il colore di sfondo della diapositiva a blu.
slide->get_Background()->set_Type(BackgroundType::OwnBackground);
slide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
slide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// Salva la presentazione su disco.
presentation->Save(u"SolidColorBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Imposta uno sfondo a tinta unita per una diapositiva master**

Aspose.Slides consente di impostare un colore solido come sfondo per la diapositiva master in una presentazione. La diapositiva master funge da modello che controlla la formattazione per tutte le diapositive, quindi quando scegli un colore solido per lo sfondo della diapositiva master, questo viene applicato a ogni diapositiva.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/).
2. Imposta il [BackgroundType](https://reference.aspose.com/slides/it/cpp/aspose.slides/backgroundtype/) della diapositiva master (tramite `get_Masters`) su `OwnBackground`.
3. Imposta il [FillType](https://reference.aspose.com/slides/it/cpp/aspose.slides/filltype/) dello sfondo della diapositiva master su `Solid`.
4. Usa il metodo [get_SolidFillColor](https://reference.aspose.com/slides/it/cpp/aspose.slides/fillformat/get_solidfillcolor/) per specificare il colore di sfondo solido.
5. Salva la presentazione modificata.

Il seguente esempio C++ mostra come impostare un colore solido (verde foresta) come sfondo per una diapositiva master:

```cpp
// Crea un'istanza della classe Presentation.
auto presentation = MakeObject<Presentation>();

auto masterSlide = presentation->get_Master(0);

// Imposta il colore di sfondo per la diapositiva Master a Verde foresta.
masterSlide->get_Background()->set_Type(BackgroundType::OwnBackground);
masterSlide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
masterSlide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_ForestGreen());

// Salva la presentazione su disco.
presentation->Save(u"MasterSlideBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Imposta uno sfondo a gradiente per una diapositiva**

Una sfumatura è un effetto grafico creato da una variazione graduale di colore. Quando viene usata come sfondo di una diapositiva, la sfumatura può rendere la presentazione più artistica e professionale. Aspose.Slides consente di impostare un colore a gradiente come sfondo per le diapositive.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/).
2. Imposta il [BackgroundType](https://reference.aspose.com/slides/it/cpp/aspose.slides/backgroundtype/) della diapositiva su `OwnBackground`.
3. Imposta il [FillType](https://reference.aspose.com/slides/it/cpp/aspose.slides/filltype/) dello sfondo della diapositiva su `Gradient`.
4. Usa il metodo [get_GradientFormat](https://reference.aspose.com/slides/it/cpp/aspose.slides/fillformat/get_gradientformat/) su [FillFormat](https://reference.aspose.com/slides/it/cpp/aspose.slides/fillformat/) per configurare le impostazioni della sfumatura desiderate.
5. Salva la presentazione modificata.

Il seguente esempio C++ mostra come impostare un colore a gradiente come sfondo per una diapositiva:

```cpp
// Crea un'istanza della classe Presentation.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

// Applica un effetto a gradiente allo sfondo.
slide->get_Background()->set_Type(BackgroundType::OwnBackground);
slide->get_Background()->get_FillFormat()->set_FillType(FillType::Gradient);
slide->get_Background()->get_FillFormat()->get_GradientFormat()->set_TileFlip(TileFlip::FlipBoth);

// Salva la presentazione su disco.
presentation->Save(u"GradientBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Imposta un'immagine come sfondo della diapositiva**

Oltre a riempimenti solidi e a gradiente, Aspose.Slides consente di usare immagini come sfondo delle diapositive.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/).
2. Imposta il [BackgroundType](https://reference.aspose.com/slides/it/cpp/aspose.slides/backgroundtype/) della diapositiva su `OwnBackground`.
3. Imposta il [FillType](https://reference.aspose.com/slides/it/cpp/aspose.slides/filltype/) dello sfondo della diapositiva su `Picture`.
4. Carica l'immagine che desideri usare come sfondo della diapositiva.
5. Aggiungi l'immagine alla collezione di immagini della presentazione.
6. Usa il metodo [get_PictureFillFormat](https://reference.aspose.com/slides/it/cpp/aspose.slides/fillformat/get_picturefillformat/) su [FillFormat](https://reference.aspose.com/slides/it/cpp/aspose.slides/fillformat/) per assegnare l'immagine come sfondo.
7. Salva la presentazione modificata.

Il seguente esempio C++ mostra come impostare un'immagine come sfondo per una diapositiva:

```cpp
// Crea un'istanza della classe Presentation.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

// Imposta le proprietà dell'immagine di sfondo.
slide->get_Background()->set_Type(BackgroundType::OwnBackground);
slide->get_Background()->get_FillFormat()->set_FillType(FillType::Picture);
slide->get_Background()->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);

// Carica l'immagine.
auto image = Images::FromFile(u"Tulips.jpg");
// Aggiungi l'immagine alla collezione di immagini della presentazione.
auto ppImage = presentation->get_Images()->AddImage(image);
image->Dispose();

slide->get_Background()->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(ppImage);

// Salva la presentazione su disco.
presentation->Save(u"ImageAsBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Il seguente esempio di codice mostra come impostare il tipo di riempimento di sfondo su un'immagine a mosaico e modificare le proprietà del mosaico:

```cpp
auto presentation = MakeObject<Presentation>();

auto firstSlide = presentation->get_Slide(0);

auto background = firstSlide->get_Background();

background->set_Type(BackgroundType::OwnBackground);
background->get_FillFormat()->set_FillType(FillType::Picture);

auto newImage = Images::FromFile(u"image.png");
auto ppImage = presentation->get_Images()->AddImage(newImage);
newImage->Dispose();

// Set the image used for the background fill.
auto backPictureFillFormat = background->get_FillFormat()->get_PictureFillFormat();
backPictureFillFormat->get_Picture()->set_Image(ppImage);

// Set the picture fill mode to Tile and adjust the tile properties.
backPictureFillFormat->set_PictureFillMode(PictureFillMode::Tile);
backPictureFillFormat->set_TileOffsetX(15.0);
backPictureFillFormat->set_TileOffsetY(15.0);
backPictureFillFormat->set_TileScaleX(46.0);
backPictureFillFormat->set_TileScaleY(87.0);
backPictureFillFormat->set_TileAlignment(RectangleAlignment::Center);
backPictureFillFormat->set_TileFlip(TileFlip::FlipY);

presentation->Save(u"TileBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert color="primary" %}}
Leggi di più: [**Immagine a piastrelle come texture**](/slides/it/cpp/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **Modifica la trasparenza dell'immagine di sfondo**

Potresti voler regolare la trasparenza dell'immagine di sfondo di una diapositiva per far risaltare il contenuto della diapositiva. Il seguente codice C++ mostra come modificare la trasparenza per un'immagine di sfondo di diapositiva:

```cpp
auto transparencyValue = 30; // Ad esempio.

// Ottieni la collezione delle operazioni di trasformazione dell'immagine.
auto imageTransform = slide->get_Background()->get_FillFormat()->get_PictureFillFormat()->get_Picture()->get_ImageTransform();

// Trova un effetto di trasparenza a percentuale fissa esistente.
SharedPtr<IAlphaModulateFixed> transparencyOperation;
for (auto&& operation : imageTransform)
{
    if (ObjectExt::Is<IAlphaModulateFixed>(operation))
    {
        transparencyOperation = ExplicitCast<IAlphaModulateFixed>(operation);
        break;
    }
}

// Imposta il nuovo valore di trasparenza.
if (transparencyOperation == nullptr)
{
    imageTransform->AddAlphaModulateFixedEffect(100.0f - transparencyValue);
}
else
{
    transparencyOperation->set_Amount(100.0f - transparencyValue);
}
```

## **Recupera il valore di sfondo della diapositiva**

Aspose.Slides fornisce l'interfaccia [IBackgroundEffectiveData](https://reference.aspose.com/slides/it/cpp/aspose.slides/ibackgroundeffectivedata/) per recuperare i valori di sfondo effettivi di una diapositiva. Questa interfaccia espone il [FillFormat](https://reference.aspose.com/slides/it/cpp/aspose.slides/ibackgroundeffectivedata/get_fillformat/) e l'[EffectFormat](https://reference.aspose.com/slides/it/cpp/aspose.slides/ibackgroundeffectivedata/get_effectformat/) effettivi.

Utilizzando il metodo `get_Background` della classe [BaseSlide](https://reference.aspose.com/slides/it/cpp/aspose.slides/baseslide/), è possibile ottenere lo sfondo effettivo per una diapositiva.

Il seguente esempio C++ mostra come ottenere il valore di sfondo effettivo di una diapositiva:

```cpp
// Crea un'istanza della classe Presentation.
auto presentation = MakeObject<Presentation>(u"Sample.pptx");

auto slide = presentation->get_Slide(0);

// Recupera lo sfondo effettivo, tenendo conto di master, layout e tema.
auto effBackground = slide->get_Background()->GetEffective();

if (effBackground->get_FillFormat()->get_FillType() == FillType::Solid)
{
    Console::WriteLine(u"Fill color: {0}", effBackground->get_FillFormat()->get_SolidFillColor());
}
else
{
    Console::WriteLine(u"Fill type: {0}", ObjectExt::ToString(effBackground->get_FillFormat()->get_FillType()));
}
```

## **FAQ**

**Posso ripristinare uno sfondo personalizzato e riportare lo sfondo del tema/layout?**

Sì. Rimuovi il riempimento personalizzato della diapositiva e lo sfondo verrà nuovamente ereditato dalla diapositiva di [layout](/slides/it/cpp/slide-layout/)/[master](/slides/it/cpp/slide-master/) corrispondente (cioè dallo [sfondo del tema](/slides/it/cpp/presentation-theme/)).

**Cosa succede allo sfondo se cambio successivamente il tema della presentazione?**

Se una diapositiva ha un proprio riempimento, rimarrà invariato. Se lo sfondo è ereditato dal [layout](/slides/it/cpp/slide-layout/)/[master](/slides/it/cpp/slide-master/), verrà aggiornato per corrispondere al [nuovo tema](/slides/it/cpp/presentation-theme/).