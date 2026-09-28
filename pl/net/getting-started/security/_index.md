---
title: Bezpieczeństwo
type: docs
weight: 160
url: /pl/net/security/
keywords:
- bezpieczeństwo
- zależności
- komponenty firm trzecich
- NuGet
- skanowanie luk
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Sprawdź, jak Aspose.Slides for .NET przetwarza prezentacje, od jakich pakietów NuGet zależy dla każdego frameworka docelowego oraz jakie komponenty firm trzecich zawiera."
---
## **Bezpieczeństwo w Aspose.Slides**

Aspose stosuje najlepsze praktyki przy tworzeniu swoich produktów.

* Aspose.Slides for .NET służy do manipulacji prezentacjami i konwertowania ich na inne formaty. Nie uruchamia skryptów w prezentacjach. Aspose.Slides analizuje strukturę prezentacji i umożliwia kodowi użytkownika końcowego wygodne manipulowanie modelem obiektów.
* Aspose.Slides działa jako biblioteka, która analizuje i interpretuje dokumenty bez wykonywania zdalnego kodu. Wszystkie produkty Aspose działają na twoich maszynach. Nie przesyłają żadnych danych do Aspose. Jedynym wyjątkiem jest [metered license](https://purchase.aspose.com/faqs/licensing/metered): jeśli używasz takiej licencji, przetwarzane są jedynie informacje o zużyciu API.
* Komponenty Aspose uruchamiane są w tym samym kontekście użytkownika co zwykłe aplikacje. Dlatego komponenty Aspose nie stanowią zagrożenia dla kluczowych zasobów systemowych. Ponadto, gdy komponent Aspose otwiera dokument, makra nie są uruchamiane automatycznie.
* Ryzyka inherentne lub związane z pakietem Microsoft Office nie mają zastosowania do komponentów Aspose, dlatego produkty Aspose są bardzo bezpieczne.

## **Zależności NuGet**

Aspose.Slides for .NET zależy od pakietów publikowanych przez Microsoft na NuGet. Zależności różnią się w zależności od pakietu i frameworka docelowego:

| Pakiet | Framework docelowy | Zależności |
|---|---|---|
| Aspose.Slides.NET | `net462` | System.Text.Json |
| Aspose.Slides.NET | `net6.0` | System.Drawing.Common, System.Security.Cryptography.Xml |
| Aspose.Slides.NET | `netstandard2.0` | System.Drawing.Common, System.Security.Cryptography.Xml, System.Text.Encoding.CodePages, System.Text.Json |
| Aspose.Slides.NET6.CrossPlatform | `net6.0` | System.Security.Cryptography.Xml |

**Zależności** sekcja [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) oraz [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/) na NuGet wymienia minimalną wersję każdej zależności dla każdego wydania.

Kiedy dodajesz Aspose.Slides do projektu, NuGet przywraca również zależności tych pakietów. Aby wyświetlić wszystkie pakiety, które przywraca twój projekt, włączając te zależności tranzytywne, uruchom to polecenie w folderze projektu:

```bash
dotnet list package --include-transitive
```

Aby sprawdzić ten sam zestaw pakietów pod kątem znanych luk bezpieczeństwa, uruchom:

```bash
dotnet list package --vulnerable --include-transitive
```

Dla innych metod audytu pakietów NuGet, zobacz [Audyt zależności pakietów pod kątem luk bezpieczeństwa](https://learn.microsoft.com/en-us/nuget/concepts/auditing-packages).

## **Komponenty firm trzecich**

Aspose.Slides zawiera kod pochodzący z otwartoźródłowych komponentów firm trzecich. Są one częścią produktu, a nie oddzielnymi pakietami NuGet, więc narzędzia odczytujące jedynie zależności NuGet ich nie wyświetlają. Oba pakiety zawierają plik *thirdpartylicenses.Aspose.Slides.for.NET.pdf*, który wymienia komponenty oraz ich licencje:

| Komponent | Licencja podana w informacji |
|---|---|
| DotNetZip | Microsoft Public License (Ms-PL) |
| ANTLR | BSD License |
| sfntly | Apache License 2.0 |
| Skia | BSD-style license |
| HarfBuzz | "Old MIT" license |
| Boost | Boost Software License 1.0 |
| Double Conversion | BSD-style license |
| ICU (International Components for Unicode) | Unicode copyright and terms of use |

## **FAQ**

**Jakie systemy są używane do monitorowania luk w kodzie Aspose?**

Przeprowadzamy statyczną analizę kodu dla każdego wydania Aspose.Slides. Możemy dostarczyć raporty bezpieczeństwa, które dowodzą, że kod Aspose.Slides spełnia wytyczne OWASP Top 10.

**Czy Aspose.Slides używa zewnętrznych pakietów?**

Tak. Zależy od pakietów Microsoft NuGet wymienionych w [Zależności NuGet](#nuget-dependencies) oraz zawiera komponenty firm trzecich wymienione w [Komponenty firm trzecich](#third-party-components). Uwzględnij oba w swojej analizie bezpieczeństwa i użyj `dotnet list package --vulnerable --include-transitive`, aby sprawdzić pakiety NuGet, które przywraca twój projekt.