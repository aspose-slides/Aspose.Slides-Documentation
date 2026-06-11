---
title: Zarządzanie dostępnością prezentacji w PHP
linktitle: Dostępność prezentacji
type: docs
weight: 30
url: /pl/php-java/presentation-accessibility/
keywords:
- dostępność prezentacji
- oznacz jako dekoracyjne
- PowerPoint
- OpenDocument
- prezentacja
- PHP
- Aspose.Slides
description: "Dowiedz się, jak Aspose.Slides pomaga automatyzować kontrole dostępności prezentacji w plikach PPT, PPTX i ODP — popraw doświadczenie czytników ekranu oraz zwiększ zgodność."
---
## **Przegląd**

Dostępność prezentacji zapewnia, że osoby korzystające z technologii wspomagających — takich jak czytniki ekranu, wyświetlacze brajlowskie lub nawigacja wyłącznie klawiaturą — mogą rozumieć i przeglądać twoje slajdy tak skutecznie, jak widzące osoby używające myszy. Dobre praktyki koncentrują się na klarownej kolejności czytania, znaczącym tekście alternatywnym dla wizualizacji informacyjnych, wystarczającym kontraście kolorów, czytelnej typografii, opisowym tekście linków oraz unikaniu przekazywania znaczenia wyłącznie za pomocą koloru lub położenia. Gdy dostępność jest planowana od samego początku, rezultatem jest czystsza struktura, bardziej spójne wizualizacje oraz treść, która dociera do każdego odbiorcy bez obejść.

## **Oznacz jako dekoracyjne**

Flaga “Mark as decorative” oznacza wyłącznie ornamentacyjne elementy wizualne, dzięki czemu czytniki ekranu pomijają je, redukując szum i koncentrując się na istotnej treści. Stosuj ją do tła, ozdobników i odstępników — nigdy do wykresów, ikon ani obrazów przekazujących informacje. Aspose.Slides udostępnia tę flagę do wykrywania i weryfikacji, umożliwiając automatyczne kontrole dostępności oraz czyszczenie.

![Oznacz jako dekoracyjne](mark_as_decorative.png)

Poniższy przykład kodu pokazuje, jak określić, czy kształt jest oznaczony jako dekoracyjny.

```php
$presentation = new Presentation("sample.pptx");
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    echo "Is shape decorative: " . ($shape->isDecorative() ? "true" : "false") . "\n";
} finally {
    $presentation->dispose();
}
```