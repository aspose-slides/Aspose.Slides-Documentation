---
title: Установка лицензии Aspose.Slides для SharePoint
type: docs
weight: 10
url: /ru/sharepoint/installing-aspose-slides-for-sharepoint-license/
description: "Установите лицензию Aspose.Slides для SharePoint на ферму SharePoint: добавьте решение лицензии в хранилище решений, разверните его и проверьте, что в преобразованных файлах больше нет водяного знака оценки."
---
{{% alert color="info" title="Примечание" %}}

Как только вы будете довольны оценочной версией, вы можете [приобрести лицензию](https://purchase.aspose.com/pricing/slides/ru/sharepoint/). Перед покупкой убедитесь, что вы понимаете и согласны с условиями подписки на лицензию. Лицензия будет отправлена вам по электронной почте после оплаты заказа.

Лицензия представляет собой ZIP‑архив, содержащий обычный пакет решения SharePoint. В архиве находятся:

- Aspose.Slides.SharePoint.License.wsp – файл пакета решения SharePoint. Лицензия упакована как решение SharePoint, чтобы упростить развертывание и откат на ферме серверов.
- readme.txt – Инструкции по установке лицензии.

{{% /alert %}}

## **Развёртывание лицензии**

Установка лицензии выполняется из консоли сервера с помощью **stsadm.exe**.

{{% alert color="info" title="Примечание" %}}

Для наглядности в следующем разделе пути опущены.

{{% /alert %}}

Выполните следующие шаги, чтобы развернуть лицензию Aspose.Slides for SharePoint:

1. Запустите stsadm, чтобы добавить решение в хранилище решений SharePoint:

   ```bat
   Stsadm.exe -o addsolution -filename Aspose.Slides.SharePoint.License.wsp
   ```

2. Разверните решение на всех серверах фермы:

   ```bat
   Stsadm.exe -o deploysolution -name Aspose.Slides.SharePoint.License.wsp -immediate -force
   ```

3. Выполните административные таймер‑задания, чтобы немедленно завершить развертывание:

   ```bat
   Stsadm.exe -o execadmsvcjobs
   ```

Операция `addsolution` принимает путь к файлу решения в параметре `-filename`; операция `deploysolution` принимает имя уже находящегося в хранилище решения в параметре `-name`.

{{% alert color="info" title="Примечание" %}}

При выполнении шага развертывания вы получите предупреждение, если служба администрирования SharePoint не запущена. **stsadm.exe** зависит от этой службы и службы таймера SharePoint для репликации данных решения по ферме. Если эти службы не работают на вашей ферме серверов, возможно, потребуется развернуть лицензию на каждом сервере отдельно.

{{% /alert %}}

{{% alert color="info" title="Примечание" %}}

В SharePoint 2010 и более поздних версиях команды оболочки управления SharePoint `Add-SPSolution`, `Install-SPSolution` и `Start-SPAdminJob` соответствуют операциям `addsolution`, `deploysolution` и `execadmsvcjobs`. См. [Сопоставление Stsadm с Microsoft PowerShell в SharePoint Server](https://learn.microsoft.com/en-us/sharepoint/technical-reference/stsadm-to-microsoft-powershell-mapping).

{{% /alert %}}

## **Проверка лицензии**

Чтобы убедиться, что лицензия установлена правильно, преобразуйте любую презентацию в новый формат. Если в преобразованном файле отсутствует оценочный водяной знак, лицензия активна.