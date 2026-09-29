---
title: Krav för Security Manager
type: docs
weight: 190
url: /sv/java/declaration/
keywords:
- Security Manager
- säkerhetspolicy
- AllPermission
- behörigheter
- sandlåda
- JDK 24
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "Vilka Security Manager-behörigheter Aspose.Slides for Java och koden som anropar den behöver på Java 23 och tidigare, och varför det inte finns något att konfigurera på Java 24 och senare."
---
## **Översikt**

Java Security Manager begränsar vad kod kan göra enligt en säkerhetspolicy. Java 17 avrådde från den för borttagning ([JEP 411](https://openjdk.org/jeps/411)), och Java 24 inaktiverade den permanent ([JEP 486](https://openjdk.org/jeps/486)). Denna artikel förklarar vad Aspose.Slides for Java behöver när en applikation fortfarande körs med en Security Manager. Om din applikation inte aktiverar en, vilket är standard, finns det inget att konfigurera.

## **Java 23 och tidigare**

När en Security Manager är aktiverad måste säkerhetspolicyn bevilja dessa behörigheter till Aspose.Slides JAR‑filen och till applikationskoden som anropar den:

- `java.util.PropertyPermission "*", "read"`: Aspose.Slides läser systemegenskaper.
- `java.io.FilePermission "<<ALL FILES>>", "read"`: Aspose.Slides läser teckensnitts‑filer och andra filer.
- `java.io.FilePermission "<<ALL FILES>>", "execute"`: Aspose.Slides startar operativsystemprogram, till exempel `reg` på Windows och `fc-match` på Linux.
- `java.io.FilePermission` med `write`‑åtgärden för de mappar där din applikation sparar filer.

Att bevilja behörigheterna enbart till JAR‑filen är inte tillräckligt: koden som anropar Aspose.Slides behöver dem också. Att bevilja `java.security.AllPermission` till båda fungerar också.

Utan behörighet att läsa systemegenskaper eller att starta program misslyckas Aspose.Slides vid första användning: att skapa ett [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/)‑objekt kastar ett `ExceptionInInitializerError`. Utan läs‑åtkomst till teckensnitten misslyckas sparande av en presentation som PDF med felmeddelandet "Cannot find any fonts installed on the system".

## **Java 24 och senare**

Security Manager kan inte aktiveras på Java 24 och senare, så det finns inga behörigheter att bevilja. Aspose.Slides körs med behörigheterna för kontot som kör din applikation. För att begränsa vad en applikation kan komma åt rekommenderar OpenJDK‑projektet tekniker utanför JDK, såsom containrar, hypervisorer och operativsystems‑sandlådefunktioner. Se [JEP 486](https://openjdk.org/jeps/486).

## **FAQ**

**Kan jag använda Aspose.Slides i en miljö som kör applikationer under en restriktiv Security Manager‑policy?**

Endast om policyn beviljar de ovanlistade behörigheterna både till Aspose.Slides och till koden som anropar den. De inkluderar läsning av alla filer och start av vilket program som helst.