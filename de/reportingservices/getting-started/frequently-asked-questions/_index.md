---
title: Häufig gestellte Fragen
type: docs
weight: 110
url: /reportingservices/frequently-asked-questions/
---

{{% alert color="primary" %}} 

Diese Seite sammelt eine Anzahl häufig gestellter Fragen zu:

- [Unterstützte Dateiformate](#Unterstützte-Dateiformate).
- [Unterstützung für Power BI Reporting-Dienste](#Unterstützung-für-Power-BI-Reporting-Dienste).
- [Installation](#Installation).
- [Exportkonfiguration](#Exportkonfiguration).

{{% /alert %}} 
### **Unterstützte Dateiformate**
#### **F: In welche Formate können Sie Berichte mit Aspose.Slides für Reporting Services exportieren?**
**A**: Mit Aspose.Slides für Reporting Services ist es möglich, jeden Bericht im PPT, PPS, PPTX, PPSX, XPS oder RPL-Format zu exportieren.
### **Unterstützung für Power BI Reporting-Dienste**
#### **F: Unterstützt Aspose.Slides für Reporting Services Power BI?**
**A**: Ja. Aspose.Slides für Reporting Services unterstützt den Export von paginierten Berichten (RDL) in Power BI.
### **Installation**
#### **F: Das Installationsprogramm startet nicht. Die manuelle Installation führt nicht zum gewünschten Ergebnis.**
**A** : Stellen Sie sicher, dass das .NET Framework 3.5 auf Ihrem System installiert ist.
#### **F: Exportoptionen fehlen nach der Installation von Aspose.Slides für Reporting Services.**
**A**: Wenn eine Codegruppe in rssrvpolicy.config nicht richtig funktioniert, kann es sein, dass der Parser der Konfigurationsdatei die letzten Abschnitte der Gruppe überspringt. Verschieben Sie daher alle Codegruppen, die mit Aspose.Slides für Reporting Services verbunden sind, an den Anfang des Blocks, der die Aspose.Slides für Reporting Services Codegruppen enthält.
#### **F: Konnte die Datei oder die Assembly Aspose.Slides.ReportingServices nicht laden (Ausführungsberechtigung kann nicht erworben werden \ Ausnahme von HRESULT: 0x80131418).**
**A**: Der Fehlercode (0x80131418) zeigt an, dass das dll-Modul nicht über ausreichende Rechte verfügt. Dies kann auf eine Sicherheitsfunktion zurückzuführen sein, die den vollständigen Zugriff auf die .dll-Datei blockiert hat, wenn sie von einem anderen Computer erhalten wurde. Dies kann behoben werden, indem das Eigenschaftenfenster der dll-Datei geöffnet und die Schaltfläche "Entsperren" im Bereich "Sicherheit" angeklickt wird.
#### **F: Lizenz 'Aspose.Slides.Reporting.Services.lic' kann nicht gefunden werden.**
**A**: Die Lizenzdatei muss sich neben der dll oder im Verzeichnis Program Files(x86)\Aspose\Slides\ befinden.
### **Exportkonfiguration**
#### **F: Wie kann ich die Farbe von Hyperlinks in einem exportierten Bericht ändern?**
**A**: Jede Rendering-Erweiterung von Aspose.Slides für Reporting Services in der rsreportserver.config hat ihre eigene Konfiguration. Um die Farbe des Hyperlinks zu ändern, setzen Sie den erforderlichen Wert im <HyperlinkColor>-Abschnitt.
#### **F: In exportierten Präsentationen wird Text in Tabellen vertikal gestreckt.**
**A**: Dies geschieht, um das Dokument leichter lesbar zu machen. Um den Text in der Tabelle so anzuzeigen, wie er im Bericht erscheint, setzen Sie die erforderliche Aspose.Slides für Reporting Services-Erweiterung in der Konfigurationsdatei rsreportserver.config auf "Normal".