---
title: Anforderungen an den Security Manager
type: docs
weight: 190
url: /de/java/declaration/
keywords:
- Security Manager
- Sicherheitsrichtlinie
- AllPermission
- Berechtigungen
- Sandbox
- JDK 24
- PowerPoint
- OpenDocument
- Präsentation
- Java
- Aspose.Slides
description: "Welche Security Manager-Berechtigungen Aspose.Slides für Java und der aufrufende Code auf Java 23 und früher benötigen und warum es auf Java 24 und später nichts zu konfigurieren gibt."
---
## **Übersicht**

Der Java Security Manager begrenzt, was Code gemäß einer Sicherheitsrichtlinie tun kann. Java 17 hat ihn zur Entfernung veraltet markiert ([JEP 411](https://openjdk.org/jeps/411)), und Java 24 hat ihn dauerhaft deaktiviert ([JEP 486](https://openjdk.org/jeps/486)). Dieser Artikel erklärt, was Aspose.Slides für Java benötigt, wenn eine Anwendung noch mit einem Security Manager ausgeführt wird. Wenn Ihre Anwendung keinen aktiviert, was standardmäßig der Fall ist, muss nichts konfiguriert werden.

## **Java 23 und früher**

Wenn ein Security Manager aktiviert ist, muss die Sicherheitsrichtlinie diese Berechtigungen sowohl der Aspose.Slides‑JAR‑Datei als auch dem Anwendungscode, der sie aufruft, gewähren:

- `java.util.PropertyPermission "*", "read"`: Aspose.Slides liest System‑Properties.
- `java.io.FilePermission "<<ALL FILES>>", "read"`: Aspose.Slides liest Schriftdateien und andere Dateien.
- `java.io.FilePermission "<<ALL FILES>>", "execute"`: Aspose.Slides startet Programme des Betriebssystems, zum Beispiel `reg` unter Windows und `fc-match` unter Linux.
- `java.io.FilePermission` mit der `write`‑Aktion für die Ordner, in denen Ihre Anwendung Dateien speichert.

Das Gewähren der Berechtigungen nur für die JAR‑Datei reicht nicht aus: Der Code, der Aspose.Slides aufruft, benötigt sie ebenfalls. Das Gewähren von `java.security.AllPermission` für beide funktioniert ebenfalls.

Ohne die Berechtigung, System‑Properties zu lesen oder Programme zu starten, schlägt Aspose.Slides beim ersten Aufruf fehl: Das Erzeugen eines [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/)‑Objekts löst einen `ExceptionInInitializerError` aus. Ohne Lesezugriff auf die Schriftdateien schlägt das Speichern einer Präsentation als PDF mit dem Fehler „Cannot find any fonts installed on the system“ fehl.

## **Java 24 und später**

Der Security Manager kann in Java 24 und später nicht aktiviert werden, daher gibt es keine Berechtigungen zu gewähren. Aspose.Slides läuft mit den Berechtigungen des Kontos, das Ihre Anwendung ausführt. Um zu beschränken, auf was eine Anwendung zugreifen kann, empfiehlt das OpenJDK‑Projekt Technologien außerhalb des JDK, wie Container, Hypervisoren und Sandbox‑Funktionen des Betriebssystems. Siehe [JEP 486](https://openjdk.org/jeps/486).

## **FAQ**

**Kann ich Aspose.Slides in einer Umgebung verwenden, in der Anwendungen unter einer restriktiven Security‑Manager‑Richtlinie laufen?**

Nur wenn die Richtlinie die oben aufgeführten Berechtigungen sowohl Aspose.Slides als auch dem aufrufenden Code gewährt. Sie umfassen das Lesen aller Dateien und das Starten beliebiger Programme.