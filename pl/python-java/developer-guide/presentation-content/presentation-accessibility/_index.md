---
title: Zarządzanie dostępnością prezentacji w Pythonie przy użyciu Java
linktitle: Dostępność prezentacji
type: docs
weight: 30
url: /pl/python-java/presentation-accessibility/
keywords:
- dostępność prezentacji
- oznacz jako dekoracyjny
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Java
- Aspose.Slides
description: "Odkryj, jak Aspose.Slides for Python via Java pomaga automatyzować kontrole dostępności prezentacji w plikach PPT, PPTX i ODP — popraw doświadczenie czytników ekranu i zwiększ zgodność."
---
## **Wprowadzenie**

Dostępność prezentacji zapewnia, że osoby korzystające z technologii pomocniczych — takich jak czytniki ekranu, wyświetlacze Braille’a czy nawigacja wyłącznie klawiaturą — mogą rozumieć i poruszać się po slajdach tak efektywnie, jak widzący odbiorcy używający myszy. Dobre praktyki koncentrują się na klarownej kolejności czytania, znaczących tekstach alternatywnych dla wizualizacji informacyjnych, wystarczającym kontraście kolorów, czytelnej typografii, opisowych tekstach odnośników oraz unikaniu przekazywania znaczenia wyłącznie za pomocą koloru lub położenia. Gdy dostępność jest planowana od samego początku, rezultat to czystsza struktura, bardziej spójne elementy wizualne oraz treść docierająca do każdego widza bez konieczności obejść.

## **Oznacz jako dekoracyjny**

Flaga „Oznacz jako dekoracyjny” służy do oznaczania wyłącznie ozdobnych elementów, aby czytniki ekranu je pomijały, ograniczając szum i koncentrując się na treściach istotnych. Stosuj ją w tle, ozdobnikach i odstępnikach — nigdy w wykresach, ikonach ani obrazach przekazujących informacje. Aspose.Slides udostępnia tę flagę do wykrywania i walidacji, umożliwiając automatyczne kontrole dostępności i czyszczenie.

![Oznacz jako dekoracyjny](mark_as_decorative.png)

Poniższy przykład kodu pokazuje, jak sprawdzić, czy kształt jest oznaczony jako dekoracyjny.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("sample.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    print(f"Is shape decorative: {shape.isDecorative()}")
finally:
    presentation.dispose()
```