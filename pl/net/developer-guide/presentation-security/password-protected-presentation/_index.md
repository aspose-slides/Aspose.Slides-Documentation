---
title: Prezentacje zabezpieczone hasłem w .NET
linktitle: Ochrona hasłem
type: docs
weight: 20
url: /pl/net/password-protected-presentation/
keywords:
- prezentacja zabezpieczona hasłem
- hasło otwierające
- szyfrowanie PowerPoint
- deszyfrowanie PowerPoint
- walidacja hasła prezentacji
- sprawdzanie hasła prezentacji
- otwieranie zaszyfrowanej prezentacji
- usuwanie szyfrowania
- PowerPoint
- PPT
- PPTX
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Szyfruj, wykrywaj, waliduj, otwieraj i odszyfrowuj prezentacje PowerPoint PPT i PPTX zabezpieczone hasłem w C# przy użyciu Aspose.Slides dla .NET."
---
## **Przegląd**

Hasło otwierające szyfruje prezentację. Poprawne hasło jest wymagane do załadowania i wyświetlenia zawartości prezentacji, więc ta ochrona zapewnia poufność.

Hasło otwierające różni się od hasła zabezpieczającego przed zapisem. Zabezpieczenie przed zapisem ogranicza modyfikację, ale nie szyfruje zawartości ani nie uniemożliwia załadowania prezentacji. Aby zarządzać hasłami do modyfikacji prezentacji, zobacz [Zabezpiecz prezentacje przed zapisem](/slides/pl/net/write-protected-presentation/).

Poniższe przepływy pracy odnoszą się zarówno do prezentacji PPT, jak i PPTX. Przykłady używają obu formatów, gdy istotne jest zachowanie oparte na pliku i strumieniu.

## **Szyfrowanie prezentacji przy użyciu hasła otwierającego**

Użyj [IProtectionManager.Encrypt](https://reference.aspose.com/slides/pl/net/aspose.slides/iprotectionmanager/encrypt/), aby przypisać hasło otwierające. Następnie użyj [IPresentation.Save](https://reference.aspose.com/slides/pl/net/aspose.slides/ipresentation/save/), aby zapisać zaszyfrowaną prezentację.

Poniższy przykład szyfruje prezentację PPTX:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");

presentation.ProtectionManager.Encrypt("open_password");
presentation.Save("encrypted-pres.pptx", SaveFormat.Pptx);
```

## **Utrzymaj właściwości dokumentu publiczne**

Domyślnie Aspose.Slides uwzględnia właściwości dokumentu w szyfrowaniu prezentacji. Właściwość [IProtectionManager.EncryptDocumentProperties](https://reference.aspose.com/slides/pl/net/aspose.slides/iprotectionmanager/encryptdocumentproperties/) kontroluje to zachowanie niezależnie od szyfrowania zawartości slajdów. Ustaw ją na `false` przed wywołaniem [IProtectionManager.Encrypt](https://reference.aspose.com/slides/pl/net/aspose.slides/iprotectionmanager/encrypt/), gdy system indeksujący, klasyfikujący, wyszukujący lub zarządzający dokumentami musi odczytać metadane bez hasła otwierającego.

Poniższy przykład tworzy zaszyfrowaną prezentację PPTX, pozostawiając jej wbudowane właściwości dokumentu publiczne:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var properties = presentation.DocumentProperties;
properties.Author = "Contoso Knowledge Management";
properties.Title = "Quarterly Product Roadmap";
properties.Keywords = "roadmap, planning, internal";

presentation.Slides[0].Name = "Encrypted presentation content";
presentation.ProtectionManager.EncryptDocumentProperties = false;
presentation.ProtectionManager.Encrypt("open_password");
presentation.Save("public-properties-encrypted.pptx", SaveFormat.Pptx);
```

Ustawienie `EncryptDocumentProperties` na `false` nie powoduje, że slajdy, mastery, układy, kształty, multimedia ani inna zawartość prezentacji stają się publiczne. Dotyczy to wyłącznie właściwości dokumentu. Aby odczytać te właściwości bez ładowania zaszyfrowanej zawartości, zobacz [Zarządzaj właściwościami prezentacji](/slides/pl/net/presentation-properties/).

## **Ładowanie zaszyfrowanej prezentacji**

Ustaw [LoadOptions.Password](https://reference.aspose.com/slides/pl/net/aspose.slides/loadoptions/password/) na hasło otwierające i przekaż opcje do [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/) podczas ładowania pliku. Ładowanie nie powiedzie się, gdy wymagane jest hasło otwierające, a podane hasło jest brakujące lub nieprawidłowe.

```csharp
using Aspose.Slides;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-pres.pptx", loadOptions);

// Pracuj z odszyfrowaną prezentacją.
```

## **Usunięcie szyfrowania z prezentacji**

Załaduj prezentację wraz z jej hasłem otwierającym, wywołaj [IProtectionManager.RemoveEncryption](https://reference.aspose.com/slides/pl/net/aspose.slides/iprotectionmanager/removeencryption/) i zapisz wynik. Zapisana prezentacja może być później ładowana bez hasła.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-pres.pptx", loadOptions);

presentation.ProtectionManager.RemoveEncryption();
presentation.Save("encryption-removed.pptx", SaveFormat.Pptx);
```

## **Walidacja hasła otwierającego przed ładowaniem**

Użyj [IPresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/pl/net/aspose.slides/ipresentationfactory/getpresentationinfo/), aby uzyskać [IPresentationInfo](https://reference.aspose.com/slides/pl/net/aspose.slides/ipresentationinfo/) bez tworzenia pełnej instancji prezentacji. Sprawdź [IPresentationInfo.IsPasswordProtected](https://reference.aspose.com/slides/pl/net/aspose.slides/ipresentationinfo/ispasswordprotected/) przed żądaniem lub weryfikacją hasła. Gdy zabezpieczenie jest obecne, zweryfikuj podaną wartość przy użyciu [IPresentationInfo.CheckPassword](https://reference.aspose.com/slides/pl/net/aspose.slides/ipresentationinfo/checkpassword/).

### **Przepływ pracy z ścieżką pliku**

Poniższy przykład weryfikuje hasło otwierające dla pliku PPTX, przekazuje zweryfikowaną wartość do [LoadOptions.Password](https://reference.aspose.com/slides/pl/net/aspose.slides/loadoptions/password/), a następnie ładuje pełną prezentację:

```csharp
using System;
using Aspose.Slides;

var filePath = "protected-presentation.pptx";
var password = "open_password";
var presentationInfo = PresentationFactory.Instance.GetPresentationInfo(filePath);

if (!presentationInfo.IsPasswordProtected)
{
    Console.WriteLine("The presentation does not have an opening password.");
}
else if (!presentationInfo.CheckPassword(password))
{
    Console.WriteLine("The opening password is incorrect.");
}
else
{
    var loadOptions = new LoadOptions { Password = password };
    using var presentation = new Presentation(filePath, loadOptions);

    Console.WriteLine("The presentation was validated and loaded successfully.");
}
```

### **Przepływ pracy ze strumieniem**

Przeciążenie strumieniowe [IPresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/pl/net/aspose.slides/ipresentationfactory/getpresentationinfo/) zapewnia taki sam przepływ pracy. Zresetuj pozycję strumienia umożliwiającego przeszukiwanie przed załadowaniem pełnej prezentacji z tego strumienia.

Poniższy przykład używa pliku PPT:

```csharp
using System;
using System.IO;
using Aspose.Slides;

var password = "open_password";
using var presentationStream = File.OpenRead("protected-presentation.ppt");
var presentationInfo = PresentationFactory.Instance.GetPresentationInfo(presentationStream);

if (!presentationInfo.IsPasswordProtected)
{
    Console.WriteLine("The presentation does not have an opening password.");
}
else if (!presentationInfo.CheckPassword(password))
{
    Console.WriteLine("The opening password is incorrect.");
}
else
{
    presentationStream.Position = 0;

    var loadOptions = new LoadOptions { Password = password };
    using var presentation = new Presentation(presentationStream, loadOptions);

    Console.WriteLine("The presentation was validated and loaded successfully.");
}
```

### **Wartości zwracane przez CheckPassword**

Metoda [IPresentationInfo.CheckPassword](https://reference.aspose.com/slides/pl/net/aspose.slides/ipresentationinfo/checkpassword/) zwraca `true` tylko wtedy, gdy prezentacja posiada hasło otwierające i podane hasło jest prawidłowe. Zwraca `false` w każdym z następujących przypadków:

- Hasło jest nieprawidłowe.
- Prezentacja nie posiada hasła otwierającego.
- Podane hasło jest `null` lub puste.

Zachowanie jest takie samo dla prezentacji PPT i PPTX.

## **Sprawdzenie, czy załadowana prezentacja jest zaszyfrowana**

Po załadowaniu prezentacji przy użyciu prawidłowego hasła, sprawdź [IProtectionManager.IsEncrypted](https://reference.aspose.com/slides/pl/net/aspose.slides/iprotectionmanager/isencrypted/), aby potwierdzić, że źródłowa prezentacja była zaszyfrowana. Aby wykryć ochronę hasłem otwierającym przed ładowaniem, użyj `IPresentationInfo.IsPasswordProtected` jak pokazano powyżej.

```csharp
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-pres.pptx", loadOptions);

var isEncrypted = presentation.ProtectionManager.IsEncrypted;
Console.WriteLine("The presentation is encrypted: " + isEncrypted);
```

## **Zalecenia bezpieczeństwa**

{{% alert color="warning" title="Bezpieczeństwo" %}}
Nie zapisuj haseł otwierających w logach ani nie dołączaj ich do komunikatów diagnostycznych. Unikaj niepotrzebnych, powtarzających się prób weryfikacji, przechowuj hasła w pamięci tylko tak długo, jak jest to konieczne, oraz ponownie używaj wyniku udanej weryfikacji przy natychmiastowym ładowaniu prezentacji.

Publiczne właściwości dokumentu mogą ujawniać nazwiska autorów, tytuły, tematy, słowa kluczowe, informacje o firmie, komentarze i wartości niestandardowe, mimo że zawartość prezentacji jest zaszyfrowana. Szyfruj wrażliwe metadane razem z prezentacją. Pozostawienie właściwości publicznych powinno być świadomą decyzją podjętą wyłącznie wtedy, gdy systemy muszą indeksować, klasyfikować, wyszukiwać lub zarządzać plikiem bez hasła otwierającego.
{{% /alert %}}

## **Zabezpieczenie prezentacji hasłem online**

1. Otwórz aplikację [Aspose.Slides Lock](https://products.aspose.app/slides/pl/lock).
2. Wybierz lub prześlij prezentację.
3. Wprowadź hasło zabezpieczające podgląd.
4. Opcjonalnie wprowadź osobne hasło zabezpieczające edycję.
5. Zastosuj zabezpieczenie i pobierz powstały plik.

{{% alert color="info" title="Zobacz także" %}}
- [Zabezpiecz prezentacje przed zapisem](/slides/pl/net/write-protected-presentation/)
- [Podpis cyfrowy w PowerPoint](/slides/pl/net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Najczęściej zadawane pytania**

**Jaka jest różnica między hasłem otwierającym a hasłem zabezpieczającym przed zapisem?**

Hasło otwierające szyfruje prezentację i jest wymagane do załadowania jej zawartości. Hasło zabezpieczające przed zapisem ogranicza modyfikację bez szyfrowania zawartości.

**Czy mogę zweryfikować hasło otwierające bez ładowania wszystkich slajdów?**

Tak. Pobierz informacje o prezentacji, sprawdź, czy istnieje ochrona hasłem otwierającym, i zweryfikuj hasło przed utworzeniem pełnej instancji prezentacji.

**Czy aplikacja może odczytać metadane bez hasła otwierającego?**

Tak, ale tylko wtedy, gdy prezentacja została zaszyfrowana z ustawieniem `EncryptDocumentProperties` na `false`. Aplikacja musi wtedy użyć trybu ładowania wyłącznie właściwości dokumentu opisanego w [Zarządzaj właściwościami prezentacji](/slides/pl/net/presentation-properties/).

**Czy przepływy weryfikacji hasła obsługują zarówno PPT, jak i PPTX?**

Tak. Wykrywanie i weryfikacja hasła w oparciu o ścieżkę pliku oraz strumień zachowują się tak samo dla prezentacji PPT i PPTX.