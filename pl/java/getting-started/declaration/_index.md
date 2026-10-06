---
title: Wymagania Menedżera Bezpieczeństwa
type: docs
weight: 190
url: /pl/java/declaration/
keywords:
- Menedżer Bezpieczeństwa
- polityka bezpieczeństwa
- AllPermission
- uprawnienia
- piaskownica
- JDK 24
- PowerPoint
- OpenDocument
- prezentacja
- Java
- Aspose.Slides
description: "Jakie uprawnienia Menedżera Bezpieczeństwa potrzebują Aspose.Slides for Java oraz kod, który go wywołuje, w Java 23 i wcześniejszych, oraz dlaczego nie ma nic do skonfigurowania w Java 24 i późniejszych."
---
## **Przegląd**

Menedżer Bezpieczeństwa Javy ogranicza, co kod może robić zgodnie z polityką bezpieczeństwa. Java 17 oznaczyła go jako przestarzały z zamiarem usunięcia ([JEP 411](https://openjdk.org/jeps/411)), a Java 24 wyłączyła go na stałe ([JEP 486](https://openjdk.org/jeps/486)). Ten artykuł wyjaśnia, czego wymaga Aspose.Slides for Java, gdy aplikacja nadal działa z Menedżerem Bezpieczeństwa. Jeśli Twoja aplikacja nie włącza go, co jest domyślne, nie ma nic do skonfigurowania.

## **Java 23 i starsze**

Gdy Menedżer Bezpieczeństwa jest włączony, polityka bezpieczeństwa musi przyznać następujące uprawnienia plikowi JAR Aspose.Slides oraz kodowi aplikacji, który go wywołuje:

- `java.util.PropertyPermission "*", "read"`: Aspose.Slides odczytuje właściwości systemowe.
- `java.io.FilePermission "<<ALL FILES>>", "read"`: Aspose.Slides odczytuje pliki czcionek i inne pliki.
- `java.io.FilePermission "<<ALL FILES>>", "execute"`: Aspose.Slides uruchamia programy systemu operacyjnego, np. `reg` w systemie Windows i `fc-match` w systemie Linux.
- `java.io.FilePermission` z akcją `write` dla folderów, w których aplikacja zapisuje pliki.

Przyznanie uprawnień tylko plikowi JAR nie wystarczy: kod wywołujący Aspose.Slides również ich potrzebuje. Przyznanie `java.security.AllPermission` obu również działa.

Bez uprawnienia do odczytu właściwości systemowych lub uruchamiania programów Aspose.Slides kończy działanie przy pierwszym użyciu: tworzenie obiektu [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/) powoduje wyrzucenie `ExceptionInInitializerError`. Brak dostępu do odczytu plików czcionek powoduje niepowodzenie zapisu prezentacji jako PDF z błędem „Cannot find any fonts installed on the system”.

## **Java 24 i nowsze**

Menedżer Bezpieczeństwa nie może być włączony w Java 24 i nowszych, więc nie ma uprawnień do przyznania. Aspose.Slides działa z uprawnieniami konta, które uruchamia Twoją aplikację. Aby ograniczyć, do czego aplikacja ma dostęp, projekt OpenJDK zaleca technologie spoza JDK, takie jak kontenery, hypervisory i funkcje sandboxingu systemu operacyjnego. Zobacz [JEP 486](https://openjdk.org/jeps/486).

## **FAQ**

**Czy mogę używać Aspose.Slides w środowisku, w którym aplikacje uruchamiane są pod restrykcyjną polityką Menedżera Bezpieczeństwa?**

Tylko jeśli polityka przyznaje wymienione wyżej uprawnienia zarówno Aspose.Slides, jak i kodowi, który go wywołuje. Obejmują one odczyt wszystkich plików i uruchamianie dowolnego programu.