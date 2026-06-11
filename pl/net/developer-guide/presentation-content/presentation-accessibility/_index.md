---
title: Zarządzanie dostępnością prezentacji w .NET
linktitle: Dostępność prezentacji
type: docs
weight: 30
url: /pl/net/presentation-accessibility/
keywords:
- dostępność prezentacji
- oznacz jako dekoracyjne
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Zautomatyzuj sprawdzanie dostępności prezentacji w plikach PPT, PPTX i ODP przy użyciu Aspose.Slides dla .NET — popraw doświadczenie czytników ekranu i zwiększ zgodność."
---
## **Wstęp**

Umożliwienie dostępności prezentacji zapewnia, że osoby korzystające z technologii wspomagających — takich jak czytniki ekranu, wyświetlacze brajlowskie lub nawigacja wyłącznie za pomocą klawiatury — mogą rozumieć i nawigować po slajdach tak skutecznie, jak widzący odbiorcy korzystający z myszy. Dobre praktyki koncentrują się na przejrzystej kolejności czytania, znaczących opisach alternatywnych dla wizualizacji informacyjnych, odpowiednim kontraście kolorów, czytelnej typografii, opisowym tekście odnośników oraz unikaniu przekazywania znaczenia wyłącznie za pomocą koloru lub położenia. Gdy dostępność jest planowana od samego początku, rezultat to czystsza struktura, bardziej spójne elementy wizualne i treść docierająca do każdego odbiorcy bez obejść.

## **Oznacz jako dekoracyjne**

Oznaczenie jako dekoracyjne oznacza wyłącznie ozdobne elementy wizualne, aby czytniki ekranu je pomijały, co zmniejsza szum i utrzymuje uwagę na treści o znaczeniu. Stosuj je w tle, ozdobnikach i odstępnikach — nigdy w wykresach, ikonach ani obrazach przekazujących informacje. Aspose.Slides udostępnia to oznaczenie do wykrywania i walidacji, umożliwiając automatyczne sprawdzanie dostępności i czyszczenie.

![Mark as Decorative](mark_as_decorative.png)

```cs
using var presentation = new Presentation("sample.pptx");

var shape = presentation.Slides[0].Shapes[0];
Console.WriteLine($"Is shape decorative: {shape.IsDecorative}");
```