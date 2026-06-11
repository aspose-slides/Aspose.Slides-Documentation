---
title: Zarządzaj dostępnością prezentacji w C++
linktitle: Dostępność prezentacji
type: docs
weight: 30
url: /pl/cpp/presentation-accessibility/
keywords:
- dostępność prezentacji
- oznacz jako dekoracyjne
- PowerPoint
- OpenDocument
- prezentacja
- C++
- Aspose.Slides
description: "Odkryj, jak Aspose.Slides for C++ pomaga automatyzować kontrole dostępności prezentacji w plikach PPT, PPTX i ODP — popraw doświadczenie czytników ekranu i zwiększ zgodność."
---
## **Przegląd**

Dostępność prezentacji zapewnia, że osoby używające technologii wspomagających — takich jak czytniki ekranu, wyświetlacze brajlowskie lub nawigacja wyłącznie przy użyciu klawiatury — mogą rozumieć i nawigować po twoich slajdach tak skutecznie, jak widzący odbiorcy korzystający z myszy. Dobre praktyki koncentrują się na wyraźnym porządku czytania, znaczących opisach alternatywnych dla informacyjnych grafik, wystarczającym kontraście kolorów, czytelnej typografii, opisowym tekście linków oraz unikaniu przekazywania znaczenia wyłącznie za pomocą koloru lub położenia. Gdy dostępność jest planowana od samego początku, rezultat to czystsza struktura, bardziej spójne elementy wizualne i treść docierająca do każdego widza bez obejść.

## **Oznacz jako dekoracyjne**

Oznaczenie jako dekoracyjne oznacza czysto ozdobne elementy wizualne, aby czytniki ekranu je pomijały, redukując szum i utrzymując fokus na istotnej treści. Stosuj je w tle, ozdobach i odstępnikach — nigdy w wykresach, ikonach ani obrazach przekazujących informacje. Aspose.Slides udostępnia to oznaczenie do wykrywania i walidacji, umożliwiając automatyczne kontrole dostępności i sprzątanie.

![Oznacz jako dekoracyjne](mark_as_decorative.png)

Poniższy przykład kodu pokazuje, jak określić, czy kształt jest oznaczony jako dekoracyjny.

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto shape = presentation->get_Slide(0)->get_Shape(0);
Console::WriteLine(u"Is shape decorative: {0}", shape->get_IsDecorative());

presentation->Dispose();
```