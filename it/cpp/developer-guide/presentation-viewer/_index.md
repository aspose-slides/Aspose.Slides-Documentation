---
title: Crea un visualizzatore di presentazioni in C++
linktitle: Visualizzatore di presentazioni
type: docs
weight: 50
url: /it/cpp/presentation-viewer/
keywords:
- visualizzare la presentazione
- visualizzatore di presentazioni
- creare visualizzatore di presentazioni
- visualizzare PPT
- visualizzare PPTX
- visualizzare ODP
- PowerPoint
- OpenDocument
- presentazione
- C++
- Aspose.Slides
description: "Crea un visualizzatore di presentazioni personalizzato in C++ utilizzando Aspose.Slides. Visualizza facilmente i file PowerPoint e OpenDocument senza Microsoft PowerPoint."
---
## **Introduzione**

Aspose.Slides per C++ viene utilizzato per creare file di presentazione con diapositive. Queste diapositive possono essere visualizzate aprendo le presentazioni in Microsoft PowerPoint, ad esempio. Tuttavia, a volte gli sviluppatori potrebbero aver bisogno di visualizzare le diapositive come immagini nel visualizzatore di immagini preferito o di creare il proprio visualizzatore di presentazioni. In tali casi, Aspose.Slides consente di esportare una singola diapositiva come immagine. Questo articolo descrive come farlo.

## **Generare un'immagine SVG da una diapositiva**

Per generare un'immagine SVG da una diapositiva di una presentazione con Aspose.Slides, seguire i passaggi seguenti:

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/).
2. Ottenere il riferimento alla diapositiva tramite il suo indice.
3. Aprire uno stream di file.
4. Salvare la diapositiva come immagine SVG nello stream del file.

```cpp
auto slideIndex = 0;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(slideIndex);

auto svgStream = File::Create(u"output.svg");
slide->WriteAsSvg(svgStream);
svgStream->Dispose();

presentation->Dispose();
```

## **Generare un SVG con ID di forma personalizzato**

Aspose.Slides può essere utilizzato per generare un [SVG](https://docs.fileformat.com/page-description-language/svg/) da una diapositiva con un ID di forma personalizzato. Per fare ciò, utilizzare il metodo `set_Id` dell'interfaccia [ISvgShape](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/isvgshape/). `CustomSvgShapeFormattingController` può essere usato per impostare l'ID della forma.

```cpp
auto slideIndex = 0;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(slideIndex);

auto svgOptions = MakeObject<SVGOptions>();
svgOptions->set_ShapeFormattingController(MakeObject<CustomSvgShapeFormattingController>());

auto svgStream = File::Create(u"output.svg");
slide->WriteAsSvg(svgStream, svgOptions);
svgStream->Dispose();

presentation->Dispose();
```
```cpp
class CustomSvgShapeFormattingController : public ISvgShapeFormattingController
{
private:
    int m_shapeIndex;

public:
    CustomSvgShapeFormattingController(int shapeStartIndex = 0)
    {
        m_shapeIndex = shapeStartIndex;
    }

    void FormatShape(SharedPtr<ISvgShape> svgShape, SharedPtr<IShape> shape)
    {
        svgShape->set_Id(String::Format(u"shape-{0}", m_shapeIndex++));
    }
};
```

## **Creare un'immagine miniatura di una diapositiva**

Aspose.Slides aiuta a generare immagini miniature delle diapositive. Per generare una miniatura di una diapositiva usando Aspose.Slides, seguire i passaggi seguenti:

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/).
2. Ottenere il riferimento alla diapositiva tramite il suo indice.
3. Ottenere l'immagine miniatura della diapositiva di riferimento a una scala definita.
4. Salvare l'immagine miniatura in qualsiasi formato immagine desiderato.

```cpp
auto slideIndex = 0;
auto scaleX = 1;
auto scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(slideIndex);

auto image = slide->GetImage(scaleX, scaleY);
image->Save(u"output.jpg", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **Creare una miniatura della diapositiva con dimensioni definite dall'utente**

Per creare un'immagine miniatura di una diapositiva con dimensioni definite dall'utente, seguire i passaggi seguenti:

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/).
2. Ottenere il riferimento alla diapositiva tramite il suo indice.
3. Ottenere l'immagine miniatura della diapositiva di riferimento con le dimensioni definite.
4. Salvare l'immagine miniatura in qualsiasi formato immagine desiderato.

```cpp
auto slideIndex = 0;
auto slideSize = Size(1200, 800);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(slideIndex);

auto image = slide->GetImage(slideSize);
image->Save(u"output.jpg", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **Creare una miniatura della diapositiva con note del relatore**

Per generare la miniatura di una diapositiva con le note del relatore usando Aspose.Slides, seguire i passaggi seguenti:

1. Creare un'istanza della classe [RenderingOptions](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/renderingoptions/).
2. Utilizzare il metodo `RenderingOptions.set_SlidesLayoutOptions` per impostare la posizione delle note del relatore.
3. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/).
4. Ottenere il riferimento alla diapositiva tramite il suo indice.
5. Ottenere l'immagine miniatura della diapositiva di riferimento con le opzioni di rendering.
6. Salvare l'immagine miniatura in qualsiasi formato immagine desiderato.

```cpp
auto slideIndex = 0;

auto layoutingOptions = MakeObject<NotesCommentsLayoutingOptions>();
layoutingOptions->set_NotesPosition(NotesPositions::BottomTruncated);

auto renderingOptions = MakeObject<RenderingOptions>();
renderingOptions->set_SlidesLayoutOptions(layoutingOptions);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(slideIndex);

auto image = slide->GetImage(renderingOptions);
image->Save(u"output.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **Esempio live**

È possibile provare l'app gratuita [**Aspose.Slides Viewer**](https://products.aspose.app/slides/it/viewer/) per vedere cosa si può implementare con l'API di Aspose.Slides:

![Visualizzatore PowerPoint online](online-PowerPoint-viewer.png)

## **FAQ**

**Posso incorporare un visualizzatore di presentazioni in un'applicazione web?**

Sì. È possibile utilizzare Aspose.Slides sul lato server per rendere le diapositive come immagini o HTML e visualizzarle nel browser. Le funzionalità di navigazione e zoom possono essere implementate con JavaScript per un'esperienza interattiva.

**Qual è il modo migliore per visualizzare le diapositive all'interno di un visualizzatore personalizzato?**

L'approccio consigliato è rendere ogni diapositiva come immagine (ad es., PNG o SVG) o convertirla in HTML usando Aspose.Slides, quindi visualizzare l'output all'interno di un picture box (per desktop) o di un contenitore HTML (per il web).

**Come gestisco presentazioni di grandi dimensioni con molte diapositive?**

Per presentazioni di grandi dimensioni, considerare il caricamento lazy o il rendering su richiesta delle diapositive. Ciò significa generare il contenuto di una diapositiva solo quando l'utente vi accede, riducendo l'utilizzo di memoria e i tempi di caricamento.