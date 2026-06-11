---
title: Zabezpiecz prezentacje hasłami przy użyciu Pythona
linktitle: Ochrona hasłem
type: docs
weight: 20
url: /pl/python-net/password-protected-presentation/
keywords:
- zablokuj PowerPoint
- zablokuj prezentację
- odblokuj PowerPoint
- odblokuj prezentację
- zabezpiecz PowerPoint
- zabezpiecz prezentację
- ustaw hasło
- dodaj hasło
- zaszyfruj PowerPoint
- zaszyfruj prezentację
- odszyfruj PowerPoint
- odszyfruj prezentację
- ochrona przed zapisem
- bezpieczeństwo PowerPoint
- bezpieczeństwo prezentacji
- usuń hasło
- usuń ochronę
- usuń szyfrowanie
- wyłącz hasło
- wyłącz ochronę
- usuń ochronę przed zapisem
- prezentacja PowerPoint
- Python
- Aspose.Slides
description: "Dowiedz się, jak łatwo blokować i odblokowywać prezentacje PowerPoint oraz OpenDocument chronione hasłem przy użyciu Aspose.Slides dla Pythona w środowisku .NET. Zwiększ swoją wydajność i zabezpiecz prezentacje dzięki naszemu przewodnikowi krok po kroku."
---
## **Wstęp**

Kiedy zabezpieczasz prezentację hasłem, oznacza to ustawienie hasła, które wymusza określone ograniczenia na prezentacji. Aby usunąć te ograniczenia, należy wprowadzić hasło. Prezentacja chroniona hasłem jest traktowana jako zablokowana prezentacja.

Zazwyczaj możesz ustawić hasło, aby wymusić te ograniczenia na prezentacji:

- **Modyfikacja**

  Jeśli chcesz, aby tylko wybrani użytkownicy mogli modyfikować Twoją prezentację, możesz ustawić ograniczenie modyfikacji. Ograniczenie to uniemożliwia osobom modyfikowanie, zmienianie lub kopiowanie elementów w prezentacji (chyba że podadzą hasło).

  Jednak w tym przypadku, nawet bez hasła, użytkownik będzie mógł uzyskać dostęp do dokumentu i otworzyć go. W trybie tylko do odczytu użytkownik może przeglądać zawartość – hiperłącza, animacje, efekty i inne elementy – wewnątrz prezentacji, ale nie może kopiować elementów ani zapisywać prezentacji.

- **Otwieranie**

  Jeśli chcesz, aby tylko wybrani użytkownicy mogli otworzyć Twoją prezentację, możesz ustawić ograniczenie otwierania. Ograniczenie to uniemożliwia osobom nawet przeglądanie zawartości prezentacji (chyba że podadzą hasło).

  Technicznie ograniczenie otwierania zapobiega również modyfikacji prezentacji: gdy użytkownicy nie mogą otworzyć prezentacji, nie mogą jej modyfikować ani wprowadzać zmian.

  **Uwaga** że gdy zabezpieczasz prezentację hasłem w celu uniemożliwienia jej otwarcia, plik prezentacji zostaje zaszyfrowany.

## Jak zabezpieczyć prezentację hasłem online

1. Przejdź do naszej strony [**Aspose.Slides Lock**](https://products.aspose.app/slides/pl/lock).

   ![todo:image_alt_text](slides-lock.png)

2. Kliknij **Drop or upload your files**.

3. Wybierz plik, który chcesz zabezpieczyć hasłem, na swoim komputerze.

4. Wprowadź preferowane hasło do ochrony edycji; Wprowadź preferowane hasło do ochrony podglądu.

5. Jeśli chcesz, aby użytkownicy widzieli Twoją prezentację jako ostateczną kopię, zaznacz pole wyboru **Mark as final**.

6. Kliknij **PROTECT NOW.**

7. Kliknij **DOWNLOAD NOW.**

## **Ochrona hasłem prezentacji w Aspose.Slides**
**Obsługiwane formaty**

Aspose.Slides obsługuje ochronę hasłem, szyfrowanie i podobne operacje dla prezentacji w następujących formatach:

- PPTX i PPT – Microsoft PowerPoint Presentation  
- ODP – OpenDocument Presentation  
- OTP – OpenDocument Presentation Template  

**Obsługiwane operacje**

Aspose.Slides umożliwia użycie ochrony hasłem na prezentacjach w celu zapobiegania modyfikacjom w następujący sposób:

- Szyfrowanie prezentacji  
- Ustawianie ochrony zapisu (write protection) na prezentacji  

**Inne operacje**

Aspose.Slides umożliwia wykonywanie dodatkowych zadań związanych z ochroną hasłem i szyfrowaniem w następujący sposób:

- odszyfrowywanie prezentacji; otwieranie zaszyfrowanej prezentacji  
- usuwanie szyfrowania; wyłączanie ochrony hasłem  
- usuwanie ochrony zapisu z prezentacji  
- pobieranie właściwości zaszyfrowanej prezentacji  
- sprawdzanie, czy prezentacja jest zaszyfrowana  
- sprawdzanie, czy prezentacja jest chroniona hasłem  

## **Szyfrowanie prezentacji**

Możesz zaszyfrować prezentację, ustawiając hasło. Następnie, aby zmodyfikować zablokowaną prezentację, użytkownik musi podać hasło.

Aby zaszyfrować lub zabezpieczyć prezentację hasłem, użyj metody **encrypt** (z klasy [ProtectionManager](https://reference.aspose.com/slides/pl/python-net/aspose.slides/protectionmanager/)) i przekaż hasło do tej metody, a następnie użyj metody **save**, aby zapisać teraz zaszyfrowaną prezentację.

Ten przykładowy kod pokazuje, jak zaszyfrować prezentację:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    pres.protection_manager.encrypt("123123")
    pres.save("encrypted-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **Ustawianie ochrony zapisu (Write Protection) na prezentacji**

Możesz dodać znak „Nie modyfikować” do prezentacji. W ten sposób informujesz użytkowników, że nie chcesz, aby wprowadzali zmiany w prezentacji.

**Uwaga** że proces ochrony zapisu nie szyfruje prezentacji. Dlatego użytkownicy – jeśli naprawdę chcą – mogą modyfikować prezentację, ale aby zapisać zmiany, będą musieli stworzyć nową prezentację pod inną nazwą.

Aby ustawić ochronę zapisu, użyj metody **setWriteProtection**. Ten przykładowy kod pokazuje, jak ustawić ochronę zapisu na prezentacji:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    pres.protection_manager.set_write_protection("123123")
    pres.save("write-protected-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **Odszyfrowywanie prezentacji; otwieranie zaszyfrowanej prezentacji**

Aspose.Slides umożliwia załadowanie zaszyfrowanego pliku, podając jego hasło. Aby odszyfrować prezentację, wywołaj metodę [remove_encryption](https://reference.aspose.com/slides/pl/python-net/aspose.slides/protectionmanager/) bez parametrów. Następnie będziesz musiał wprowadzić prawidłowe hasło, aby załadować prezentację.

Ten przykładowy kod pokazuje, jak odszyfrować prezentację:

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.password = "123123"
with slides.Presentation("encrypted-pres.pptx", loadOptions) as pres:
    print(pres.document_properties.author)
```

## **Usuwanie szyfrowania; wyłączanie ochrony hasłem**

Możesz usunąć szyfrowanie lub ochronę hasłem z prezentacji. W ten sposób użytkownicy będą mogli uzyskać dostęp do prezentacji lub modyfikować ją bez ograniczeń.

Aby usunąć szyfrowanie lub ochronę hasłem, wywołaj metodę [remove_encryption](https://reference.aspose.com/slides/pl/python-net/aspose.slides/protectionmanager/). Ten przykładowy kod pokazuje, jak usunąć szyfrowanie z prezentacji:

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.password = "123123"
with slides.Presentation("encrypted-pres.pptx", loadOptions) as pres:
    pres.protection_manager.remove_encryption()
    pres.save("encryption-removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Usuwanie ochrony zapisu z prezentacji**

Możesz użyć Aspose.Slides do usunięcia ochrony zapisu zastosowanej w pliku prezentacji. Dzięki temu użytkownicy mogą modyfikować prezentację dowolnie i nie otrzymują ostrzeżeń przy wykonywaniu takich operacji.

Aby usunąć ochronę zapisu z prezentacji, użyj metody [remove_write_protection](https://reference.aspose.com/slides/pl/python-net/aspose.slides/protectionmanager/). Ten przykładowy kod pokazuje, jak usunąć ochronę zapisu z prezentacji:

```py
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as pres:
    pres.protection_manager.remove_write_protection()
    pres.save("write-protection-removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Pobieranie właściwości zaszyfrowanej prezentacji**

Zazwyczaj użytkownicy mają trudności z uzyskaniem właściwości dokumentu zaszyfrowanej lub chronionej hasłem prezentacji. Aspose.Slides oferuje jednak mechanizm, który pozwala zabezpieczyć prezentację hasłem, jednocześnie umożliwiając użytkownikom dostęp do jej właściwości.

**Uwaga** że gdy Aspose.Slides szyfruje prezentację, właściwości dokumentu tej prezentacji są domyślnie również chronione hasłem. Jeśli jednak potrzebujesz, aby właściwości prezentacji były dostępne (nawet po zaszyfrowaniu prezentacji), Aspose.Slides pozwala to zrobić.

Jeżeli chcesz, aby użytkownicy zachowali możliwość dostępu do właściwości prezentacji, którą zaszyfrowałeś, ustaw właściwość [EncryptDocumentProperties](https://reference.aspose.com/slides/pl/python-net/aspose.slides/protectionmanager/) na `True`. Ten przykładowy kod pokazuje, jak zaszyfrować prezentację, jednocześnie udostępniając użytkownikom dostęp do jej właściwości dokumentu:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    pres.protection_manager.encrypt_document_properties = True
    pres.protection_manager.encrypt("123123")
```

## **Sprawdzanie, czy prezentacja jest chroniona hasłem przed jej załadowaniem**

Zanim załadujesz prezentację, możesz chcieć sprawdzić i potwierdzić, że nie jest ona chroniona hasłem. Dzięki temu unikniesz błędów i podobnych problemów, które pojawiają się przy ładowaniu prezentacji zabezpieczonej hasłem bez podania hasła.

Ten kod w Pythonie pokazuje, jak sprawdzić prezentację pod kątem ochrony hasłem (bez jej ładowania):

```python
import aspose.slides as slides

presentationInfo = slides.PresentationFactory.instance.get_presentation_info("pres.pptx")
print("The presentation is password protected: " + str(presentationInfo.is_password_protected))
```

## **Sprawdzanie, czy prezentacja jest zaszyfrowana**

Aspose.Slides umożliwia sprawdzenie, czy prezentacja jest zaszyfrowana. Aby wykonać to zadanie, użyj właściwości [is_encrypted](https://reference.aspose.com/slides/pl/python-net/aspose.slides/protectionmanager/), która zwraca `True`, jeśli prezentacja jest zaszyfrowana, lub `False`, jeśli nie jest zaszyfrowana.

Ten przykładowy kod pokazuje, jak sprawdzić, czy prezentacja jest zaszyfrowana:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    print(str(pres.protection_manager.is_encrypted))
```

## **Sprawdzanie, czy prezentacja jest chroniona przed zapisem**

Aspose.Slides umożliwia sprawdzenie, czy prezentacja jest chroniona przed zapisem. Aby wykonać to zadanie, użyj właściwości [is_write_protected](https://reference.aspose.com/slides/pl/python-net/aspose.slides/protectionmanager/), która zwraca `True`, jeśli prezentacja jest chroniona przed zapisem, lub `False`, jeśli nie jest chroniona.

Ten przykładowy kod pokazuje, jak sprawdzić, czy prezentacja jest chroniona przed zapisem:

```py
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as pres:
    print(str(pres.protection_manager.is_write_protected))
```

## **Walidacja lub potwierdzenie, że użyto konkretnego hasła do ochrony prezentacji**

Możesz chcieć sprawdzić i potwierdzić, że konkretne hasło zostało użyte do ochrony dokumentu prezentacji. Aspose.Slides zapewnia mechanizm do weryfikacji hasła.

Ten przykładowy kod pokazuje, jak zweryfikować hasło:

```py
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as pres:
    # sprawdź, czy "pass" jest dopasowane
    matched = pres.protection_manager.check_write_protection("my_password")
    print(str(matched))
```

Zwraca `True`, jeśli prezentacja została zaszyfrowana podanym hasłem. W przeciwnym razie zwraca `False`.

{{% alert color="primary" title="See also" %}} 
- [Digital Signature in PowerPoint](/slides/pl/python-net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Jakie metody szyfrowania są obsługiwane przez Aspose.Slides?**

Aspose.Slides obsługuje nowoczesne metody szyfrowania, w tym algorytmy oparte na AES, zapewniając wysoki poziom bezpieczeństwa danych Twoich prezentacji.

**Co się stanie, jeśli wprowadzono nieprawidłowe hasło przy próbie otwarcia prezentacji?**

Zostanie wyrzucony wyjątek, informujący, że dostęp do prezentacji został odmówiony. Pomaga to zapobiegać nieautoryzowanemu dostępowi i chroni zawartość prezentacji.

**Czy istnieją konsekwencje wydajnościowe przy pracy z prezentacjami chronionymi hasłem?**

Proces szyfrowania i odszyfrowywania może wprowadzić niewielkie opóźnienie podczas operacji otwierania i zapisywania. W większości przypadków wpływ na wydajność jest minimalny i nie wpływa znacząco na całkowity czas przetwarzania zadań związanych z prezentacjami.