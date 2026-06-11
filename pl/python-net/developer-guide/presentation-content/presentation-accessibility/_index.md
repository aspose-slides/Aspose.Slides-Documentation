---
title: Zarządzanie dostępnością prezentacji w Pythonie
linktitle: Dostępność prezentacji
type: docs
weight: 30
url: /pl/python-net/presentation-accessibility/
keywords:
- dostępność prezentacji
- oznacz jako dekoracyjne
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Aspose.Slides
description: "Odkryj, jak Aspose.Slides for Python pomaga automatyzować kontrolę dostępności prezentacji w plikach PPT, PPTX i ODP — popraw doświadczenie czytników ekranu i zwiększ zgodność."
---
## **Wstęp**

Accessibility prezentacji zapewnia, że osoby korzystające z technologii wspomagających — takich jak czytniki ekranu, wyświetlacze brajla lub nawigacja tylko za pomocą klawiatury — mogą rozumieć i poruszać się po slajdach tak skutecznie, jak widzące audytorium używające myszy. Dobre praktyki koncentrują się na jasnym porządku czytania, znaczącym tekście alternatywnym dla informacyjnych grafik, wystarczającym kontraście kolorów, czytelnej typografii, opisowym tekście linków oraz unikaniu przekazywania znaczenia wyłącznie za pomocą koloru lub położenia. Gdy dostępność jest planowana od początku, efektem jest czystsza struktura, bardziej spójne wizualizacje i treść docierająca do każdego odbiorcy bez obejść.

## **Oznacz jako dekoracyjne**

Oznaczenie jako dekoracyjne flaguje wyłącznie ozdobne elementy wizualne, aby czytniki ekranu je pomijały, redukując szum i utrzymując fokus na treści znaczącej. Stosuj je w tle, ornamentach i odstępnikach — nigdy w wykresach, ikonach ani obrazach przekazujących informacje. Aspose.Slides udostępnia tę flagę do wykrywania i walidacji, umożliwiając automatyczne kontrole dostępności oraz czyszczenie.

![Oznacz jako dekoracyjne](mark_as_decorative.png)

The following code sample shows how to determine whether a shape is marked as decorative.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    print(f"Is shape decorative: {shape.is_decorative}")
```