---
title: Zarządzanie czcionkami zapasowymi w prezentacjach na Androidzie
linktitle: Czcionka zapasowa
type: docs
weight: 50
url: /pl/androidjava/fallback-font/
keywords:
- czcionka zapasowa
- dostępna czcionka
- zastąpienie glifu
- określenie czcionki
- określenie reguły
- PowerPoint
- OpenDocument
- prezentacja
- Android
- Java
- Aspose.Slides
description: "Zobacz, jak Aspose.Slides for Android za pomocą Javy wykorzystuje czcionki zapasowe, aby tekst był czytelny w prezentacjach PowerPoint i OpenDocument, gdy oryginalne czcionki nie są dostępne."
---
## **Wprowadzenie**

Czcionka zapasowa jest używana, gdy czcionka określona dla tekstu jest dostępna w systemie, ale nie zawiera wymaganego glifu. W takim przypadku można użyć jednej z określonych czcionek zapasowych do zastąpienia glifu.

## **Czcionka zapasowa**

Aspose.Slides umożliwia tworzenie czcionek zapasowych, dodawanie ich do kolekcji czcionek zapasowych, ustawianie kolekcji czcionek zapasowych dla konkretnej prezentacji, usuwanie czcionek zapasowych z prezentacji, określanie reguł stosowania czcionek zapasowych i inne.

Aby zapoznać się z tymi funkcjami, użyj poniższych linków:

- [Create Fallback Font](/slides/pl/androidjava/create-fallback-font)
- [Create Fallback Fonts Collection](/slides/pl/androidjava/create-fallback-fonts-collection)
- [Render Presentation with Fallback Font](/slides/pl/androidjava/render-presentation-with-fallback-font)

## **FAQ**

**Jak czcionki zapasowe różnią się od substytucji czcionek?**

Czcionka zapasowa jest stosowana znak po znaku lub dla zakresu Unicode, gdy podstawowa czcionka nie zawiera konkretnych glifów; wypełnia tylko brakujące znaki. [Substitution](/slides/pl/androidjava/font-substitution/) zastępuje brakującą lub niedostępną czcionkę dla całego fragmentu lub części tekstu inną czcionką. Mogą być łączone, ale ich zakres i logika wyboru są różne.

**Czy ustawienia czcionki zapasowej są zapisywane w pliku prezentacji?**

Nie. Konfiguracja czcionki zapasowej istnieje w czasie przetwarzania/renderowania w bibliotece i nie jest serializowana do pliku PPTX. Prezentacja nie przechowuje reguł czcionki zapasowej.

**Czy czcionka zapasowa ma wpływ na elementy tworzone przez obiekty PowerPoint (SmartArt, wykresy, WordArt)?**

Tak. Tekst wewnątrz tych obiektów przechodzi przez tę samą ścieżkę renderowania, więc te same reguły czcionki zapasowej mają zastosowanie do niego jak do zwykłego tekstu.