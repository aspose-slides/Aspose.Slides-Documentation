---
title: Удаление лицензии Aspose.Slides для SharePoint
type: docs
weight: 20
url: /ru/sharepoint/uninstalling-aspose-slides-for-sharepoint-license/
---

Чтобы удалить лицензию, пожалуйста, выполните следующие шаги из консоли сервера. 

1. Отозвать лицензионное решение из фермы: 

``` xml

 stsadm.exe -o retractsolution -name Aspose.Slides.SharePoint.License.wsp -immediate

```

2. Выполните административные таймерные задачи, чтобы завершить отзыв немедленно: 

``` xml

 stsadm.exe -o execadmsvcjobs

```

3. Дождитесь завершения отзыва. Вы можете использовать Центр администрирования, чтобы проверить, завершился ли отзыв в разделе **Центр администрирования**, затем **Операции** и **Управление решениями**.
4. Удалите решение из хранилища решений SharePoint: 

``` xml

 stsadm.exe -o deletesolution -name Aspose.Slides.SharePoint.License.wsp

```