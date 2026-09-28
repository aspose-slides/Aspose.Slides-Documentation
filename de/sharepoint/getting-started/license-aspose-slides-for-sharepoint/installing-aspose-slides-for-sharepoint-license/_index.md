---
title: Installation der Aspose.Slides for SharePoint Lizenz
type: docs
weight: 10
url: /de/sharepoint/installing-aspose-slides-for-sharepoint-license/
description: "Installieren Sie die Aspose.Slides for SharePoint‑Lizenz in einer SharePoint‑Farm: Fügen Sie die Lizenzlösung dem Lösungs‑Store hinzu, stellen Sie sie bereit und überprüfen Sie, dass konvertierte Dateien kein Evaluierungswasserzeichen mehr enthalten."
---
{{% alert color="info" title="Hinweis" %}}

Sobald Sie mit Ihrer Evaluation zufrieden sind, können Sie [eine Lizenz erwerben](https://purchase.aspose.com/pricing/slides/sharepoint/). Stellen Sie vor dem Kauf sicher, dass Sie die Lizenz‑Abonnementbedingungen verstanden haben und ihnen zustimmen. Die Lizenz wird Ihnen per E‑Mail zugesandt, sobald die Bestellung bezahlt wurde.

Die Lizenz ist ein ZIP‑Archiv, das ein reguläres SharePoint‑Lösungspaket enthält. Das Archiv enthält:

- Aspose.Slides.SharePoint.License.wsp – die SharePoint‑Lösungsdatei. Die Lizenz ist als SharePoint‑Lösung verpackt, um die Bereitstellung und das Zurückziehen über eine Serverfarm zu vereinfachen.
- readme.txt – Anweisungen zur Lizenzinstallation.

{{% /alert %}}

## **Bereitstellung der Lizenz**

Die Lizenzinstallation wird über die Serverkonsole mit **stsadm.exe** durchgeführt.

{{% alert color="info" title="Hinweis" %}}

Die Pfade werden im folgenden Abschnitt aus Gründen der Übersichtlichkeit weggelassen.

{{% /alert %}}

Führen Sie die folgenden Schritte aus, um die Aspose.Slides for SharePoint‑Lizenz bereitzustellen:

1. Führen Sie stsadm aus, um die Lösung zum SharePoint‑Lösungsstore hinzuzufügen:

   ```bat
   Stsadm.exe -o addsolution -filename Aspose.Slides.SharePoint.License.wsp
   ```

2. Stellen Sie die Lösung auf allen Servern der Farm bereit:

   ```bat
   Stsadm.exe -o deploysolution -name Aspose.Slides.SharePoint.License.wsp -immediate -force
   ```

3. Führen Sie administrative Timer‑Jobs aus, um die Bereitstellung sofort abzuschließen:

   ```bat
   Stsadm.exe -o execadmsvcjobs
   ```

Der `addsolution`‑Vorgang erwartet den Pfad der Lösungsdatei in `-filename`; der `deploysolution`‑Vorgang erwartet den Namen der bereits im Lösungsstore vorhandenen Lösung in `-name`.

{{% alert color="info" title="Hinweis" %}}

Sie erhalten eine Warnung beim Ausführen des Bereitstellungsschritts, wenn der SharePoint‑Administrationsdienst nicht läuft. **stsadm.exe** hängt von diesem Dienst und dem SharePoint‑Timer‑Dienst ab, um Lösungsdaten über die Farm zu replizieren. Wenn diese Dienste in Ihrer Serverfarm nicht laufen, müssen Sie die Lizenz möglicherweise auf jedem Server bereitstellen.

{{% /alert %}}

{{% alert color="info" title="Hinweis" %}}

Auf SharePoint 2010 und höher entsprechen die SharePoint Management Shell‑Cmdlets `Add-SPSolution`, `Install-SPSolution` und `Start-SPAdminJob` den Vorgängen `addsolution`, `deploysolution` und `execadmsvcjobs`. Siehe [Stsadm-zu-Microsoft-PowerShell-Mapping in SharePoint Server](https://learn.microsoft.com/en-us/sharepoint/technical-reference/stsadm-to-microsoft-powershell-mapping).

{{% /alert %}}

## **Lizenz testen**

Um zu prüfen, ob die Lizenz korrekt installiert wurde, konvertieren Sie eine beliebige Präsentation in ein neues Format. Wenn im konvertierten Dokument kein Evaluierungswasserzeichen zu sehen ist, ist die Lizenz aktiv.