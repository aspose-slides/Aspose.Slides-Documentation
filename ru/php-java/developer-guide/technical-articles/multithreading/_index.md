---
title: Многопоточность в Aspose.Slides
type: docs
weight: 310
url: /ru/php-java/multithreading/
---

{{% alert color="primary" %}} 

Хотя параллельная работа с презентациями возможна (кроме парсинга/загрузки/клонирования) и в большинстве случаев всё проходит хорошо, существует небольшая вероятность получения некорректных результатов при использовании библиотеки в нескольких потоках.

Мы настоятельно рекомендуем **не** использовать единственный экземпляр [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) в многопоточной среде, так как это может привести к непредсказуемым ошибкам или сбоям, которые сложно обнаружить.

Не безопасно загружать, сохранять и/или клонировать экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) в нескольких потоках. Такие операции **не** поддерживаются. Если вам нужно выполнять такие задачи, вам необходимо параллелить операции, используя несколько однопоточных процессов — и каждый из этих процессов должен использовать свой собственный экземпляр презентации.