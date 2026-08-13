---
title: Dlaczego nie automatyzacja
type: docs
weight: 50
url: /pl/cpp/why-not-automation/
keywords:
- automatyzacja
- Microsoft Office
- porównanie
- bezpieczeństwo
- stabilność
- skalowalność
- funkcje
- PowerPoint
- OpenDocument
- prezentacja
- C++
- Aspose.Slides
description: "Poznaj przyczyny, dla których automatyzacja Office jest ryzykowna dla serwerów i usług, oraz zobacz, jak Aspose.Slides zapewnia bezpieczniejsze i szybsze przetwarzanie prezentacji dla PowerPoint i OpenDocument."
---
## **Wprowadzenie**

Jest kilka powodów, dla których komponenty Aspose są lepszą alternatywą dla automatyzacji. Niektóre z kluczowych powodów to:

- Bezpieczeństwo
- Stabilność
- Skalowalność/Szybkość
- Cena
- Funkcje

Poniżej znajduje się bardziej szczegółowe wyjaśnienie każdego kluczowego punktu.

## **Ważne pytania**
- Dlaczego komponenty Aspose są znacznie lepszą opcją niż automatyzacja Microsoft Office?

Są dwa pytania, które najczęściej słyszymy w Aspose :

- Czy Twoje produkty wymagają zainstalowanego Microsoft Office, aby mogły działać?

Krótka prosta odpowiedź to **NIE**. Aspose i komponenty Aspose są całkowicie niezależne i nie są powiązane, ani autoryzowane, sponsorowane ani w inny sposób zatwierdzone przez Microsoft Corporation.

- Dlaczego powinniśmy używać produktów Aspose zamiast wykorzystywać automatyzację Microsoft Office?

Najkrótsza odpowiedź, jaką możemy podać, to że istnieje wiele powodów, a najważniejszy jest to, że *Microsoft sam w zdecydowany sposób odradza automatyzację Office w rozwiązaniach programowych: [Microsoft Article

## **Bezpieczeństwo**
Poniżej znajduje się bezpośredni cytat z powyższego artykułu Microsoft:  
*"Aplikacje Office nigdy nie były przeznaczone do użycia po stronie serwera, dlatego nie uwzględniają problemów bezpieczeństwa, z jakimi borykają się komponenty rozproszone. Office nie uwierzytelnia przychodzących żądań i nie chroni przed nieumyślnym uruchamianiem makr ani przed uruchamianiem innego serwera, który może uruchamiać makra, z kodu po stronie serwera. Nie otwieraj plików przesłanych na serwer z anonimowej sieci! W zależności od ostatnio ustawionych ustawień zabezpieczeń, serwer może uruchamiać makra w kontekście Administratora lub Systemu z pełnymi uprawnieniami i zagrozić sieci! Dodatkowo Office używa wielu komponentów po stronie klienta (takich jak Simple MAPI, WinInet, MSDAIPP), które mogą buforować informacje uwierzytelniające klienta w celu przyspieszenia przetwarzania. Jeśli Office jest automatyzowany po stronie serwera, jedna instancja może obsługiwać więcej niż jednego klienta i ponieważ informacje uwierzytelniające zostały zbuforowane dla tej sesji, istnieje możliwość, że jeden klient może używać zbuforowanych poświadczeń innego klienta, uzyskując w ten sposób nieprzyznane uprawnienia przez podszywanie się pod innych użytkowników."*

Produkty Aspose są bardzo bezpieczne. W związku z tym komponenty Aspose nie stanowią potencjalnego ryzyka dla kluczowych zasobów systemowych. Ponadto, gdy dokument jest otwierany przez komponent Aspose, makra nie są uruchamiane automatycznie. Komponenty Aspose zostały stworzone z myślą o umożliwieniu programistom tworzenia, manipulowania i zapisywania plików Office. Żadne z ryzyk związanych z pakietem Microsoft Office nie są inherentne w komponentach Aspose.

## **Stabilność**
Poniżej znajduje się bezpośredni cytat z powyższego artykułu Microsoft:  
*"Office 2000, Office XP i Office 2003 używają technologii Microsoft Windows Installer (MSI), aby ułatwić instalację i samonaprawę użytkownikowi końcowemu. MSI wprowadza koncepcję „instalacji przy pierwszym użyciu”, co pozwala na dynamiczne instalowanie lub konfigurowanie funkcji w czasie działania (dla systemu lub częściej dla konkretnego użytkownika). W środowisku po stronie serwera opóźnia to wydajność i zwiększa prawdopodobieństwo pojawienia się okna dialogowego, które prosi użytkownika o zatwierdzenie instalacji lub podanie odpowiedniego dysku instalacyjnego. Chociaż ma to na celu zwiększenie odporności Office jako produktu dla użytkownika końcowego, implementacja możliwości MSI w Office jest niekorzystna w środowisku po stronie serwera. Ponadto stabilność Office ogólnie nie może być zapewniona przy uruchamianiu po stronie serwera, ponieważ nie została zaprojektowana ani przetestowana do tego typu użycia. Używanie Office jako komponentu usługowego na serwerze sieciowym może zmniejszyć stabilność tej maszyny, a w konsekwencji całej sieci. Jeśli planujesz automatyzację Office po stronie serwera, spróbuj odizolować program na dedykowanym komputerze, który nie może wpływać na krytyczne funkcje i który może być w razie potrzeby restartowany."*

Ponieważ komponenty Aspose są pakowane w pojedynczy plik DLL, nigdy nie będzie potrzeby instalowania dodatkowych części, aby działały. Komponenty Aspose są wykorzystywane jedynie przez aplikacje C++ i nie zawierają kodu, który czekałby na ludzką interakcję. Komponenty Aspose zostały dokładnie przetestowane i są niezwykle stabilne. Komponenty Aspose są używane przez [Companies](https://about.aspose.com/customers) takie jak: **IBM**, **Hilton**, **Reader's Digest**, **Bank of America** oraz wiele innych.

## **Skalowalność/Szybkość**
Poniżej znajduje się bezpośredni cytat z powyższego artykułu Microsoft:  
*"Komponenty po stronie serwera muszą być wysoce reentrancyjne, wielowątkowe komponenty COM o minimalnym narzucie i wysokiej przepustowości dla wielu klientów. Aplikacje Office są pod każdym względem ich dokładnym przeciwieństwem. Są to nie‑reentrancyjne serwery automatyzacji oparte na STA, przeznaczone do zapewniania różnorodnych, lecz zasobo‑intensywnych funkcji dla jednego klienta. Oferują niewielką skalowalność jako rozwiązanie po stronie serwera i mają stałe ograniczenia ważnych elementów, takich jak pamięć, które nie mogą być zmieniane poprzez konfigurację. Co ważniejsze, używają zasobów globalnych (takich jak pliki mapowane w pamięci, globalne dodatki lub szablony oraz współdzielone serwery automatyzacji), co może ograniczać liczbę jednocześnie uruchamianych instancji i prowadzić do warunków wyścigu w środowisku wieloklientowym. Programiści planujący uruchomienie więcej niż jednej instancji dowolnej aplikacji Office jednocześnie muszą rozważyć puli lub serializację dostępu do aplikacji Office, aby uniknąć potencjalnych zakleszczeń lub uszkodzenia danych.”*

Komponenty Aspose są wysoce skalowalne i błyskawicznie szybkie. Aplikacje Office nie zostały zaprojektowane do jednoczesnego użycia przez setki i tysiące użytkowników. Natomiast komponenty Aspose są do tego stworzone. Nasze komponenty to prawdziwe rozwiązanie C++ i działają bezbłędnie, zarówno na pojedynczym serwerze, napędzając jedną aplikację, jak i w środowisku zrównoważonego obciążeniowo Web Form, obsługując aplikację na skalę przedsiębiorstwa.

## **Cena**
Kiedy aplikacja korzysta z automatyzacji Microsoft Office, należy zakupić kopię Microsoft Office dla każdego komputera, na którym aplikacja jest uruchamiana. Często aplikacja musi tworzyć lub modyfikować plik Office, ale nie wymaga, aby użytkownik posiadał Microsoft Office. Aspose oferuje bardzo [Cost Effective](https://purchase.aspose.com/) i wolną od opłat licencyjnych licencję na redystrybucję, która pozwala na wdrożenie na nieograniczoną liczbę użytkowników bez obaw o licencjonowanie. Tworząc aplikacje internetowe, ważne jest, aby wiedzieć, że komponenty automatyzacji Microsoft Office nie są wyceniane ani licencjonowane dla rozwiązań po stronie serwera; w związku z tym nie ma dobrej, licencyjnej opcji wdrożenia aplikacji webowych wykorzystujących komponenty Microsoft Office. Aspose oferuje bardzo [Cost Effective](https://purchase.aspose.com/) rozwiązanie także dla aplikacji opartych na serwerze.

## **Funkcje**
Komponenty Aspose zapewniają wszystko, co potrzebne do zarządzania plikami Office, a nawet więcej. Zostały zaprojektowane z filozofią umożliwiającą programistom osiągnięcie najlepszych rezultatów przy minimalnym nakładzie pracy. W przeciwieństwie do automatyzacji Office, komponenty Aspose oferują wiele potężnych i oszczędzających czas funkcji. Na przykład, [Aspose.Cells](https://products.aspose.com/cells/cpp/) umożliwia programistom importowanie danych z **DataTable** lub **DataView** bezpośrednio do pliku Excel. [Aspose.Words](https://products.aspose.com/words/net/) oferuje podobną funkcję, pozwalającą wypełnić dokument Word (czyli Mail Merge) bezpośrednio z dowolnego obiektu danych C++. [Every Component](https://products.aspose.com/total/cpp/) z rodziny Aspose oferuje własny zestaw unikalnych i potężnych funkcji. Najlepszą częścią zakupu komponentu Aspose jest dostęp do naszych zespołów deweloperskich. Nasze zespoły rozumieją, że jeśli istnieje funkcja, której potrzebuje Twoja firma, najprawdopodobniej inne firmy również będą jej potrzebować. Choć nie każda prośba o funkcję może zostać dodana, nasze zespoły starają się być bardzo otwarte i elastyczne przy udzielaniu pomocy. To podejście pomogło komponentom Aspose stać się tak potężnymi, jakimi są. Jeśli istnieją dodatkowe funkcje, których potrzebujesz w obiektach automatyzacji Office, Twoje szanse na ich dodanie są bardzo, bardzo niskie.

## **Podsumowanie**
{{% alert color="info" %}} 

Chociaż ten artykuł oprócz wielu kluczowych powodów, dla których komponenty Aspose są lepszym wyborem niż automatyzacja Office, zawiera jeszcze wiele innych. Artykuł koncentruje się głównie na najważniejszych punktach. Wszystkie różne komponenty Aspose oferują bezpieczną, bez zobowiązań [Evaluation Version](https://downloads.aspose.com/slides/pl/cpp). Zachęcamy do skorzystania z tej [Evaluation](https://downloads.aspose.com/slides/pl/cpp), aby lepiej zobaczyć, co Aspose może zrobić dla Twoich aplikacji.
{{% /alert %}}