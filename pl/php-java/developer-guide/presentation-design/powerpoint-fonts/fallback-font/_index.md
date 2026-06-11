---
title: Zarządzanie czcionkami zapasowymi w prezentacjach w PHP
linktitle: Czcionka zapasowa
type: docs
weight: 50
url: /pl/php-java/fallback-font/
keywords:
- czcionka zapasowa
- dostępna czcionka
- zamiana glifu
- określenie czcionki
- określenie reguły
- PowerPoint
- OpenDocument
- prezentacja
- PHP
- Aspose.Slides
description: "Zobacz, jak Aspose.Slides dla PHP używa czcionek zapasowych, aby tekst był czytelny w prezentacjach PowerPoint i OpenDocument, gdy oryginalne czcionki nie są dostępne."
---
## **Wprowadzenie**

Czcionki zapasowe są używane, gdy czcionka określona dla tekstu jest dostępna w systemie, ale nie zawiera wymaganego glifu. W takim przypadku Aspose.Slides może użyć jednej z określonych czcionek zapasowych, aby zastąpić brakujący glif.

## **Czcionka zapasowa**
Czcionka zapasowa jest używana, gdy czcionka określona dla tekstu jest dostępna w systemie, ale nie zawiera potrzebnego glifu. W takim przypadku można użyć jednej z określonych czcionek zapasowych do zastąpienia brakującego glifu.

Aspose.Slides pozwala tworzyć czcionki zapasowe, dodawać je do kolekcji czcionek zapasowych, ustawiać kolekcję czcionek zapasowych dla określonej prezentacji, usuwać czcionki zapasowe z prezentacji, określać zasady stosowania czcionek zapasowych i inne.

Aby zapoznać się z tymi funkcjami, użyj poniższych linków:

- [Utwórz czcionkę zapasową](/slides/pl/php-java/create-fallback-font)
- [Utwórz kolekcję czcionek zapasowych](/slides/pl/php-java/create-fallback-fonts-collection)
- [Renderuj prezentację z czcionką zapasową](/slides/pl/php-java/render-presentation-with-fallback-font)

## **FAQ**

**Jak czcionki zapasowe różnią się od substytucji czcionek?**

Czcionka zapasowa jest stosowana na poziomie pojedynczego znaku lub zakresu Unicode, gdy podstawowa czcionka nie posiada konkretnych glifów; wypełnia tylko brakujące znaki. [Zamiana](/slides/pl/php-java/font-substitution/) zastępuje brakującą lub niedostępną czcionkę dla całego fragmentu (run) lub części tekstu inną czcionką. Mogą być używane razem, ale ich zakres i logika wyboru różnią się.

**Czy ustawienia czcionek zapasowych są zapisywane w pliku prezentacji?**

Nie. Konfiguracja czcionek zapasowych istnieje w czasie przetwarzania/renderowania w bibliotece i nie jest serializowana do pliku PPTX. Prezentacja nie przechowuje Twoich reguł czcionek zapasowych.

**Czy czcionki zapasowe wpływają na elementy tworzone przez obiekty PowerPoint (SmartArt, wykresy, WordArt)?**

Tak. Tekst wewnątrz tych obiektów przechodzi przez ten sam proces renderowania, więc te same zasady czcionek zapasowych mają zastosowanie zarówno do niego, jak i do normalnego tekstu.