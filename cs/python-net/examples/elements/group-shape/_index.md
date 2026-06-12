---
title: Skupinový tvar
type: docs
weight: 170
url: /cs/python-net/examples/elements/group-shape/
keywords:
- skupina
- přidat skupinový tvar
- přístup ke skupinovému tvaru
- odstranit skupinový tvar
- rozbalit tvary
- příklady kódu
- PowerPoint
- OpenDocument
- prezentace
- Python
- Aspose.Slides
description: "Práce se skupinovými tvary v Pythonu pomocí Aspose.Slides: vytváření a rozbalování, přeuspořádání podřízených tvarů, nastavení transformací a hranic v PowerPointu a OpenDocumentu."
---
Příklady vytváření skupin tvarů, jejich přístupu, rozbalení a odstraňování pomocí **Aspose.Slides for Python via .NET**.

## **Add a Group Shape**
Vytvořte skupinu obsahující dva základní tvary.

```py
def add_group_shape():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Přidejte skupinový tvar.
        group = slide.shapes.add_group_shape()
        group.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 0, 0, 50, 50)
        group.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 60, 0, 50, 50)

        presentation.save("group.pptx", slides.export.SaveFormat.PPTX)
```

## **Access a Group Shape**
Získejte první skupinový tvar ze snímku.

```py
def access_group_shape():
    with slides.Presentation("group.pptx") as presentation:
        slide = presentation.slides[0]

        # Přístup k prvnímu skupinovému tvaru na snímku.
        first_group = None
        for shape in slide.shapes:
            if isinstance(shape, slides.GroupShape):
                first_group = shape
                break
```

## **Remove a Group Shape**
Smažte skupinový tvar ze snímku.

```py
def remove_group_shape():
    with slides.Presentation("group.pptx") as presentation:
        slide = presentation.slides[0]

        # Předpokládáme, že první tvar je skupinový tvar.
        group = slide.shapes[0]

        # Odstraňte skupinový tvar.
        slide.shapes.remove(group)

        presentation.save("group_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Ungroup Shapes**
Přesuňte tvary mimo kontejner skupiny.

```py
def ungroup_shapes():
    with slides.Presentation("group.pptx") as presentation:
        slide = presentation.slides[0]

        # Předpokládáme, že první tvar je skupinový tvar.
        group = slide.shapes[0]

        # Přesuňte tvary mimo skupinu.
        for shape in group.shapes:
            slide.shapes.add_clone(shape)

        slide.shapes.remove(group)

        presentation.save("shapes_ungrouped.pptx", slides.export.SaveFormat.PPTX)
```