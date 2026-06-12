---
title: Gestisci SmartArt in presentazioni PowerPoint usando C++
linktitle: Gestisci SmartArt
type: docs
weight: 10
url: /it/cpp/manage-smartart/
keywords:
- SmartArt
- Testo SmartArt
- Tipo di layout
- Proprietà nascosta
- Organigramma
- Organigramma con immagine
- PowerPoint
- presentazione
- C++
- Aspose.Slides
description: "Impara a creare e modificare SmartArt PowerPoint con Aspose.Slides per C++ utilizzando esempi di codice chiari che accelerano la progettazione e l'automazione delle diapositive."
---
## **Panoramica**

SmartArt è un diagramma PowerPoint costituito da nodi, forme di nodo e un layout. Con Aspose.Slides per C++, è possibile creare SmartArt, leggere il testo dai suoi nodi, modificare il layout, ispezionare i nodi nascosti, configurare i layout dei diagrammi organizzativi e creare diagrammi organizzativi con immagine.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shape(0);

if (System::ObjectExt::Is<ISmartArt>(shape))
{
    auto smartArt = System::ExplicitCast<ISmartArt>(shape);

    for (int nodeIndex = 0; nodeIndex < smartArt->get_AllNodes()->get_Count(); nodeIndex++)
    {
        auto node = smartArt->get_AllNodes()->idx_get(nodeIndex);

        for (int shapeIndex = 0; shapeIndex < node->get_Shapes()->get_Count(); shapeIndex++)
        {
            auto nodeShape = node->get_Shape(shapeIndex);

            if (nodeShape->get_TextFrame() != nullptr)
            {
                System::Console::WriteLine(nodeShape->get_TextFrame()->get_Text());
            }
        }
    }
}

presentation->Dispose();
```

## **Ottieni testo da un oggetto SmartArt**

Un nodo SmartArt può contenere una o più forme. Per leggere il testo visibile, iterare attraverso [ISmartArt::get_AllNodes](https://reference.aspose.com/slides/it/cpp/aspose.slides.smartart/smartart/get_allnodes/), quindi leggere il [ITextFrame](https://reference.aspose.com/slides/it/cpp/aspose.slides/itextframe/) restituito da [ISmartArtShape::get_TextFrame](https://reference.aspose.com/slides/it/cpp/aspose.slides.smartart/smartartshape/get_textframe/).

```cpp
auto presentation = System::MakeObject<Presentation>();

auto smartArt = presentation->get_Slide(0)->get_Shapes()->AddSmartArt(
    10.0f, 10.0f, 400.0f, 300.0f, SmartArtLayoutType::BasicBlockList);

smartArt->set_Layout(SmartArtLayoutType::BasicProcess);

presentation->Save(u"ChangeSmartArtLayout_out.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Modifica il tipo di layout di un oggetto SmartArt**

Il layout SmartArt controlla come i nodi sono disposti e collegati. L'esempio seguente crea un oggetto SmartArt con il valore `BasicBlockList` di [SmartArtLayoutType](https://reference.aspose.com/slides/it/cpp/aspose.slides.smartart/smartartlayouttype/), lo modifica al valore `BasicProcess` e salva la presentazione.

```cpp
auto presentation = System::MakeObject<Presentation>();

auto smartArt = presentation->get_Slide(0)->get_Shapes()->AddSmartArt(
    10.0f, 10.0f, 400.0f, 300.0f, SmartArtLayoutType::RadialCycle);

auto node = smartArt->get_AllNodes()->AddNode();
bool isHidden = node->get_IsHidden();

if (isHidden)
{
    System::Console::WriteLine(u"The node is hidden in the SmartArt data model.");
}

presentation->Save(u"CheckSmartArtHiddenProperty_out.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Verifica se un nodo SmartArt è nascosto**

[ISmartArtNode::get_IsHidden](https://reference.aspose.com/slides/it/cpp/aspose.slides.smartart/smartartnode/get_ishidden/) indica se il nodo è nascosto nel modello dati di SmartArt. I nodi nascosti possono esistere nella struttura anche quando il layout selezionato non li visualizza come elementi diagramma visibili.

L'esempio seguente aggiunge un nodo a un oggetto SmartArt che utilizza il valore `RadialCycle` di [SmartArtLayoutType](https://reference.aspose.com/slides/it/cpp/aspose.slides.smartart/smartartlayouttype/) e verifica lo stato di nascondimento del nodo.

```cpp
auto presentation = System::MakeObject<Presentation>();

auto smartArt = presentation->get_Slide(0)->get_Shapes()->AddSmartArt(
    10.0f, 10.0f, 400.0f, 300.0f, SmartArtLayoutType::OrganizationChart);

auto rootNode = smartArt->get_Node(0);
rootNode->set_OrganizationChartLayout(OrganizationChartLayoutType::LeftHanging);

presentation->Save(u"OrganizationChartLayout_out.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Ottieni o imposta il layout del diagramma organizzativo**

Per i diagrammi SmartArt che utilizzano un layout di diagramma organizzativo, [ISmartArtNode::get_OrganizationChartLayout](https://reference.aspose.com/slides/it/cpp/aspose.slides.smartart/smartartnode/get_organizationchartlayout/) e [ISmartArtNode::set_OrganizationChartLayout](https://reference.aspose.com/slides/it/cpp/aspose.slides.smartart/smartartnode/set_organizationchartlayout/) definiscono come i nodi figlio sono disposti sotto un nodo padre. Ad esempio, è possibile impostare i nodi figlio in modo che pendano a sinistra, a destra o su entrambi i lati, a seconda del [OrganizationChartLayoutType](https://reference.aspose.com/slides/it/cpp/aspose.slides.smartart/organizationchartlayouttype/) selezionato.

L'esempio seguente crea un diagramma organizzativo e imposta il layout per il primo nodo al valore `LeftHanging` di [OrganizationChartLayoutType](https://reference.aspose.com/slides/it/cpp/aspose.slides.smartart/organizationchartlayouttype/).

```cpp
auto presentation = System::MakeObject<Presentation>();

auto smartArt = presentation->get_Slide(0)->get_Shapes()->AddSmartArt(
    0.0f, 0.0f, 400.0f, 400.0f, SmartArtLayoutType::PictureOrganizationChart);

presentation->Save(u"PictureOrganizationChart_out.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Crea un diagramma organizzativo con immagine**

Un diagramma organizzativo con immagine è un layout SmartArt progettato per diagrammi gerarchici che includono segnaposto immagine. Utilizzare il valore `PictureOrganizationChart` di [SmartArtLayoutType](https://reference.aspose.com/slides/it/cpp/aspose.slides.smartart/smartartlayouttype/) quando si aggiunge l'oggetto SmartArt a una diapositiva.

## **FAQ**

**SmartArt supporta il mirroring o l'inversione per le lingue RTL?**

Sì. Il metodo [SmartArt::set_IsReversed](https://reference.aspose.com/slides/it/cpp/aspose.slides.smartart/smartart/set_isreversed/) cambia la direzione del diagramma da sinistra‑destra a destra‑sinistra, o viceversa, quando il layout SmartArt selezionato supporta l'inversione.

**Come posso copiare SmartArt nella stessa diapositiva o in un'altra presentazione mantenendo la formattazione?**

È possibile [clonare la forma SmartArt](/slides/it/cpp/shape-manipulations/) con [ShapeCollection::AddClone](https://reference.aspose.com/slides/it/cpp/aspose.slides/shapecollection/addclone/) o [clonare l'intera diapositiva](/slides/it/cpp/clone-slides/) che contiene lo SmartArt. Entrambi gli approcci preservano dimensione, posizione e formattazione.

**Come posso rendere SmartArt in un'immagine raster per l'anteprima o l'esportazione web?**

[Renderizzare la diapositiva](/slides/it/cpp/convert-powerpoint-to-png/) o l'intera presentazione in PNG o JPEG. SmartArt viene renderizzato come parte della diapositiva.

**Come posso trovare un oggetto SmartArt specifico su una diapositiva se ce ne sono diversi?**

Imposta un valore distintivo su [Shape::set_AlternativeText](https://reference.aspose.com/slides/it/cpp/aspose.slides/shape/set_alternativetext/) o [Shape::set_Name](https://reference.aspose.com/slides/it/cpp/aspose.slides/shape/set_name/) sulla forma SmartArt, cerca quel valore in [BaseSlide::get_Shapes](https://reference.aspose.com/slides/it/cpp/aspose.slides/baseslide/get_shapes/), e quindi verifica che la forma corrispondente sia un [ISmartArt](https://reference.aspose.com/slides/it/cpp/aspose.slides.smartart/ismartart/).