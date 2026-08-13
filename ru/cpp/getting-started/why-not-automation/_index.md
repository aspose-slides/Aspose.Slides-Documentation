---
title: Почему не автоматизация
type: docs
weight: 50
url: /ru/cpp/why-not-automation/
keywords:
- автоматизация
- Microsoft Office
- сравнение
- безопасность
- стабильность
- масштабируемость
- функциональность
- PowerPoint
- OpenDocument
- презентация
- C++
- Aspose.Slides
description: "Узнайте, почему автоматизация Office рискованна для серверов и сервисов, и посмотрите, как Aspose.Slides обеспечивает более безопасную и быструю обработку презентаций для PowerPoint и OpenDocument."
---
## **Введение**

Существует несколько причин, почему компоненты Aspose являются лучшей альтернативой автоматизации. Ключевые причины:

- Безопасность
- Стабильность
- Масштабируемость/Скорость
- Цена
- Функциональность

Ниже представлено более подробное объяснение каждой ключевой позиции.

## **Важные вопросы**
- Почему компоненты Aspose значительно лучше, чем автоматизация Microsoft Office?

Есть два вопроса, которые мы слышим чаще всего в Aspose:

- Требуют ли ваши продукты установки Microsoft Office для их работы?

Краткий простой ответ **НЕТ**. Aspose и его компоненты полностью независимы и не являются аффилированными, авторизованными, спонсируемыми или одобренными корпорацией Microsoft.

- Почему стоит использовать продукты Aspose вместо автоматизации Microsoft Office?

Самый короткий ответ: существует множество причин, а главная — *сам Microsoft настоятельно не рекомендует автоматизацию Office из программных решений: [Microsoft Article*

## **Безопасность**
Ниже приведена прямая цитата из вышеуказанной Microsoft Article : 
*"Office Applications were never intended for use server-side, and therefore do not take into consideration the security problems that are faced by distributed components. Office does not authenticate incoming requests, and does not protect you from unintentionally running macros, or starting another server that might run macros, from your server-side code. Do not open files that are uploaded to the server from an anonymous Web! Based on the security settings that were last set, the server can run macros under an Administrator or System context with full privileges and compromise your network! In addition, Office uses many client-side components (such as Simple MAPI, WinInet, MSDAIPP) that can cache client authentication information in order to speed up processing. If Office is being automated server-side, one instance may service more than one client, and because authentication information has been cached for that session, it is possible that one client can use the cached credentials of another client, and thereby gain non-granted access permissions by impersonating other users."*

Продукты Aspose очень безопасны. Поэтому компоненты Aspose не представляют потенциального риска для жизненно важных системных ресурсов. Кроме того, при открытии документа компонентом Aspose макросы не запускаются автоматически. Компоненты Aspose созданы для того, чтобы разработчики могли создавать, изменять и сохранять файлы Office. Ни один из рисков, связанных с пакетом Microsoft Office, не является свойством компонентов Aspose.

## **Стабильность**
Ниже приведена прямая цитата из вышеуказанной Microsoft Article : 
*"Office 2000, Office XP and Office 2003 use Microsoft Windows Installer (MSI) technology to make installation and self-repair easier for an end user. MSI introduces the concept of "install on first use", which allows features to be dynamically installed or configured at runtime (for the system, or more often for a particular user). In a server-side environment this both slows down performance and increases the likelihood that a dialog box may appear that asks for the user to approve the install or provide an appropriate install disk. Although it is designed to increase the resiliency of Office as an end-user product, Office's implementation of MSI capabilities is counterproductive in a server-side environment. Furthermore, the stability of Office in general cannot be assured when run server-side because it has not been designed or tested for this type of use. Using Office as a service component on a network server may reduce the stability of that machine and as a consequence your network as a whole. If you plan to automate Office server-side, attempt to isolate the program to a dedicated computer that cannot affect critical functions, and that can be restarted as needed."*

Поскольку компоненты Aspose упакованы в один DLL, никогда не понадобится устанавливать какие‑либо дополнительные части или модули для их работы. Компоненты Aspose используются только приложениями C++ и не содержат кода, ожидающего человеческого вмешательства. Компоненты Aspose прошли тщательное тестирование и чрезвычайно стабильны. Компоненты Aspose используют такие [Companies](https://about.aspose.com/customers) как **IBM**, **Hilton**, **Reader's Digest**, **Bank of America** и многие‑многие другие.

## **Масштабируемость/Скорость**
Ниже приведена прямая цитата из вышеуказанной Microsoft Article :

*"Server-side components need to be highly reentrant, multi-threaded COM components with minimum overhead and high throughput for multiple clients. Office Applications are in almost all respects the exact opposite. They are non-reentrant, STA-based Automation servers that are designed to provide diverse but resource-intensive functionality for a single client. They offer little scalability as a server-side solution, and have fixed limits to important elements, such as memory, which cannot be changed through configuration. More importantly, they use global resources (such as memory mapped files, global add-ins or templates, and shared Automation servers), which can limit the number of instances that can run concurrently and lead to race conditions if they are configured in a multi-client environment. Developers who plan to run more then one instance of any Office Application at the same time need to consider Pooling or Serializing Access to the Office Application for avoiding potential Deadlocks or Data Corruption”.*

Компоненты Aspose обладают высокой масштабируемостью и молниеносной скоростью. Приложения Office не были созданы для одновременного использования сотнями и тысячами пользователей. Однако компоненты Aspose спроектированы именно для этого. Наши компоненты — истинное C++‑решение, которое безупречно работает как на отдельном сервере, обслуживая одно приложение, так и в сбалансированной нагрузкой веб‑форме, поддерживая предприятие в целом.

## **Цена**
При использовании автоматизации Microsoft Office необходимо покупать копию Microsoft Office для каждой машины, где работает приложение. Часто приложение должно создавать или изменять файл Office, но пользователю не требуется наличие Microsoft Office. Aspose предлагает очень [Cost Effective](https://purchase.aspose.com/) и безроялти лицензию на перераспределение, позволяющую развертывать решение неограниченному количеству пользователей без проблем с лицензированием. При создании веб‑приложений важно знать, что компоненты автоматизации Microsoft Office не лицензированы и не рассчитаны на серверные решения; поэтому отсутствует приемлемое лицензирование для веб‑развертываний, использующих эти компоненты. Aspose предлагает очень [Cost Effective](https://purchase.aspose.com/) решение и для серверных приложений.

## **Функциональность**
Компоненты Aspose предоставляют всё необходимое для работы с файлами Office и многое другое. Они созданы по принципу «как можно больше результата при минимуме усилий». В отличие от автоматизации Office, компоненты Aspose предлагают множество мощных и экономящих время функций. Например, [Aspose.Cells](https://products.aspose.com/cells/cpp/) даёт разработчикам возможность импортировать данные из **DataTable** или **DataView** непосредственно в файл Excel. [Aspose.Words](https://products.aspose.com/words/net/) предлагает аналогичную возможность заполнять Word‑документ (Mail Merge) напрямую из любого C++‑объекта данных. [Every Component](https://products.aspose.com/total/cpp/) семейства Aspose обладает своим набором уникальных и мощных возможностей. Лучшее в покупке компонента Aspose — доступ к нашим командам разработки. Наши разработчики понимают, что если какая‑то функция нужна вашей компании, то, скорее всего, она понадобится и другим. Хотя не каждое запрос может быть реализовано, наши команды стараются быть открытыми и гибкими, оказывая поддержку. Такой подход помог компонентам Aspose стать настолько мощными. Если вам требуются дополнительные функции из объектов автоматизации Office, вероятность их появления крайне низка.

## **Заключение**
{{% alert color="info" %}} 

Хотя в этой статье описаны многие ключевые причины, почему компоненты Aspose лучше, чем автоматизация Office, их гораздо больше. В статье рассматриваются только самые важные пункты. Все компоненты Aspose предоставляют бесплатную, безрисковую [Evaluation Version](https://downloads.aspose.com/slides/ru/cpp). Мы настоятельно рекомендуем воспользоваться этой [Evaluation](https://downloads.aspose.com/slides/ru/cpp), чтобы лучше увидеть, что Aspose может сделать для ваших приложений.
{{% /alert %}}