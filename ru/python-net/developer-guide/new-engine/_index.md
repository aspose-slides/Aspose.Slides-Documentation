---
title: Миграция на новый движок Python-to-.NET в версии 26.8
linktitle: Миграция на новый движок
type: docs
weight: 290
url: /ru/python-net/migrate-to-new-engine/
keywords:
- новый движок
- миграция
- aspose.pydrawing
- примитивы рисования
- Point
- Color
- Rectangle
- ImportError
- AttributeError
- Python
- Aspose.Slides
description: "Перенесите ваш код Python в новый движок Aspose.Slides версии 26.8: переместите примитивы рисования в aspose.slides и автоматически исправьте импорты."
---
## **Введение**

Версия 26.8 заменяет движок, который соединяет Python с .NET. Примитивы рисования перемещены в модуль `aspose.slides`.

Перейдите сразу к [У меня ошибка](#i-have-an-error), если после обновления у вас возникли проблемы.

### **Примитивы рисования перемещены в aspose.slides**

Перемещено семь типов. Они сохраняют свои имена, аргументы и поведение:

|Тип|До 26.8|26.8 и позже|
| :- | :- | :- |
|Point|`aspose.pydrawing.Point`|[aspose.slides.Point](https://reference.aspose.com/slides/ru/python-net/aspose.slides/point/)|
|PointF|`aspose.pydrawing.PointF`|[aspose.slides.PointF](https://reference.aspose.com/slides/ru/python-net/aspose.slides/pointf/)|
|Size|`aspose.pydrawing.Size`|[aspose.slides.Size](https://reference.aspose.com/slides/ru/python-net/aspose.slides/size/)|
|SizeF|`aspose.pydrawing.SizeF`|[aspose.slides.SizeF](https://reference.aspose.com/slides/ru/python-net/aspose.slides/sizef/)|
|Rectangle|`aspose.pydrawing.Rectangle`|[aspose.slides.Rectangle](https://reference.aspose.com/slides/ru/python-net/aspose.slides/rectangle/)|
|RectangleF|`aspose.pydrawing.RectangleF`|[aspose.slides.RectangleF](https://reference.aspose.com/slides/ru/python-net/aspose.slides/rectanglef/)|
|Color|`aspose.pydrawing.Color`|[aspose.slides.Color](https://reference.aspose.com/slides/ru/python-net/aspose.slides/color/)|

Эти семь типов составляли весь оставшийся контент `aspose.pydrawing`. Как только вы перенаправите их, вашему коду больше не нужно ссылаться на `aspose.pydrawing`, и все импорты этого модуля можно удалить. Это также упрощает проверку результата — смотрите [Проверка миграции](#verify-the-migration).

**Устаревший код:**

```python
import aspose.slides as slides
import aspose.pydrawing as drawing

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)

    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = drawing.Color.red

    with slide.get_image(drawing.Size(1920, 1080)) as slide_image:
        slide_image.save("slide1.jpeg", slides.ImageFormat.JPEG)
```

**Версия 26.8:**

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)

    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = slides.Color.red

    with slide.get_image(slides.Size(1920, 1080)) as slide_image:
        slide_image.save("slide1.jpeg", slides.ImageFormat.JPEG)
```

Форма импорта `from` изменяется так же:

```python
# Устаревший код
from aspose.pydrawing import Color, Point

# Версия 26.8
from aspose.slides import Color, Point
```

## **Исправление ошибки импорта**

Найдите трассировку в первом столбце.

|Ошибка|Причина|Исправление|
| :- | :- | :- |
|`AttributeError: module 'aspose.pydrawing' has no attribute 'Color'` (или `Point`, `Rectangle` и т.п.)|Пакет версии 26.8, а код всё ещё ссылается на старый модуль|[Обновите ваш код](#update-your-code)|
|`ImportError: cannot import name 'Color' from 'aspose.pydrawing'`|Та же причина, форма импорта `from`|[Обновите ваш код](#update-your-code)|
|`ModuleNotFoundError: No module named 'aspose.pydrawing'`|Модуль и все его семь типов перемещены в `aspose.slides`|[Обновите ваш код](#update-your-code), затем удалите импорт `aspose.pydrawing`|
|`ImportError: cannot import name 'Color' from 'aspose.slides'`|Код был мигрирован, но установленный пакет версии 26.7 или старее|`pip install --upgrade aspose.slides`|
|`TypeError` on a color, point, or size argument|Значение, созданное из `aspose.pydrawing`, передаётся в новый API|Создайте значение также из `aspose.slides`|

## **Обновите ваш код**

Поскольку `aspose.pydrawing` не содержит ничего, кроме семи перемещённых типов, миграция представляет собой переименование модуля. Все формы импорта покрываются этим единственным переименованием, включая псевдонимы:

```python
# Устаревший код
import aspose.pydrawing as drawing
color = drawing.Color.red

# Версия 26.8 - псевдоним продолжает работать
import aspose.slides as drawing
color = drawing.Color.red
```

Это корректно в любой области видимости, включая тело функции, потому что псевдоним остаётся привязанным именно там, где был привязан ранее. Единственный недостаток — вводящее в заблуждение имя, поэтому рассмотрите возможность сделать намерение явным:

```python
import aspose.slides as slides
color = slides.Color.red
```

Выберите подход, соответствующий размеру вашей кодовой базы.

### **Заменить вручную**

Для нескольких файлов найдите `aspose.pydrawing` и замените его на `aspose.slides`, затем удалите любой импорт, который больше не нужен.

### **Заменить с помощью команды оболочки**

Это простая текстовая замена, поэтому она также затрагивает вхождения внутри строк и комментариев. Обе команды создают копию `.bak` каждого изменённого файла.

**Linux:**

```bash
grep -rlZ --include='*.py' 'aspose\.pydrawing' . \
  | xargs -0 -r sed -i.bak 's/aspose\.pydrawing/aspose.slides/g'
```

В macOS используйте `sed -i ''` вместо `sed -i.bak`, или установите GNU sed как `gsed`.

**Windows PowerShell:**

```
Get-ChildItem -Recurse -Filter *.py | ForEach-Object {
  $t = Get-Content $_ -Raw
  $new = $t -replace 'aspose\.pydrawing', 'aspose.slides'
  if ($new -ne $t) {
    Copy-Item $_.FullName "$($_.FullName).bak"
    Set-Content $_.FullName $new -NoNewline
    $_.FullName
  }
}
```

Чтобы откатить изменения в Linux или macOS:

```bash
find . -name '*.py.bak' -exec sh -c 'mv "$1" "${1%.bak}"' _ {} \;
```

Чтобы откатить изменения в Windows:

```
Get-ChildItem -Recurse -Filter *.py.bak | ForEach-Object {
  Move-Item $_.FullName ($_.FullName -replace '\.bak$', '') -Force
}
```

### **Заменить с помощью скрипта Python**

Та же переименовка, портативна для Linux, macOS и Windows. Скрипт принимает путь в качестве аргумента и показывает изменения, если не указан `--write`. Добавьте `--backup`, чтобы сохранять копию `.bak` каждого изменённого файла. Сохраните его под любым именем — сообщение о использовании подхватывает имя во время выполнения.

```python
"""Переименовать aspose.pydrawing в aspose.slides. Замена простым текстом.

    python <this script> src/                     # предварительный просмотр
    python <this script> src/ --write             # применение
    python <this script> src/ --write --backup    # применение, сохраняются копии .bak
"""

import sys
from pathlib import Path

W = "--write" in sys.argv
B = "--backup" in sys.argv
ROOT = next((a for a in sys.argv[1:] if not a.startswith("-")), None)

if ROOT is None:
    sys.exit(f"usage: python {Path(sys.argv[0]).name} <path> [--write] [--backup]")

root = Path(ROOT)
if not root.exists():
    sys.exit(f"no such path: {root}")

files = [root] if root.is_file() else root.rglob("*.py")
changed = 0

for p in files:
    if {".venv", "venv", "__pycache__", ".git"} & set(p.parts):
        continue
    s = p.read_text(encoding="utf-8")
    n = s.replace("aspose.pydrawing", "aspose.slides")
    if n == s:
        continue
    changed += 1
    print(("wrote " if W else "would change ") + str(p))
    if W:
        if B:
            p.with_suffix(p.suffix + ".bak").write_text(s, encoding="utf-8")
        p.write_text(n, encoding="utf-8")

print(f"{changed} file(s) {'changed' if W else 'to change'}"
      + ("" if W or not changed else "; rerun with --write to apply"))
```

Типичный запуск выглядит так:

```console
$ python migrate.py src/
would change src/render.py
would change src/export/slides.py
2 file(s) to change; rerun with --write to apply

$ python migrate.py src/ --write --backup
wrote src/render.py
wrote src/export/slides.py
2 file(s) changed
```

Путь может быть каталогом, который обходится рекурсивно, или отдельным файлом `.py`.

### **Заменить скриптом на основе AST**

Рекомендуется для больших кодовых баз. Этот скрипт выполняет ту же переименовку, но сначала парсит каждый файл, поэтому он никогда не меняет вхождения внутри строк, комментариев или строк документации.

Поскольку он переименовывает модуль на месте и оставляет псевдонимы нетронутыми, все формы импорта обрабатываются без специальных случаев: `import aspose.pydrawing`, `import aspose.pydrawing as X`, `from aspose.pydrawing import Color`, `from aspose.pydrawing import Color as C`, многострочные импортные выражения в скобках, импорты внутри функций и модуль, передаваемый как значение. Он принимает те же флаги `--write` и `--backup`.

```python
"""Переименовать aspose.pydrawing в aspose.slides, пропуская строки и комментарии.

    python <this script> src/                     # предварительный просмотр
    python <this script> src/ --write             # применить
    python <this script> src/ --write --backup    # применить, сохраняются копии .bak
"""

import ast, sys
from pathlib import Path

MOD, DST = "aspose.pydrawing", "aspose.slides"
W = "--write" in sys.argv
B = "--backup" in sys.argv
ROOT = next((a for a in sys.argv[1:] if not a.startswith("-")), None)

if ROOT is None:
    sys.exit(f"usage: python {Path(sys.argv[0]).name} <path> [--write] [--backup]")

root = Path(ROOT)
if not root.exists():
    sys.exit(f"no such path: {root}")

files = [root] if root.is_file() else root.rglob("*.py")
changed = 0


def chain(n):
    p = []
    while isinstance(n, ast.Attribute):
        p.append(n.attr)
        n = n.value
    return ".".join(reversed(p + [n.id])) if isinstance(n, ast.Name) else None


def fix(src):
    tree = ast.parse(src)
    off, o = [], 0
    for l in src.encode().splitlines(keepends=True):
        off.append(o)
        o += len(l)
    off.append(o)
    edits = []

    for n in ast.walk(tree):
        # импорт aspose.pydrawing [as X]  /  from aspose.pydrawing import ...
        # The module name is renamed in place, so any alias stays bound as before.
        if (isinstance(n, ast.Import) and any(a.name == MOD for a in n.names)) or \
           (isinstance(n, ast.ImportFrom) and n.module == MOD):
            s, e = off[n.lineno - 1], off[n.end_lineno - 1] + n.end_col_offset
            edits.append((s, e, src.encode()[s:e].decode().replace(MOD, DST)))
        # Любое выражение, ссылающееся на модуль, включая простое `fn(aspose.pydrawing)`.
        elif isinstance(n, ast.Attribute) and chain(n) == MOD:
            edits.append((off[n.lineno - 1] + n.col_offset,
                          off[n.end_lineno - 1] + n.end_col_offset, DST))

    b = src.encode()
    for s, e, r in sorted(edits, reverse=True):  # back to front keeps offsets valid
        b = b[:s] + r.encode() + b[e:]
    return b.decode()


for p in files:
    if {".venv", "venv", "__pycache__", ".git"} & set(p.parts):
        continue
    s = p.read_text(encoding="utf-8")
    try:
        n = fix(s)
    except SyntaxError as e:
        print(f"skipped {p}: {e}")
        continue
    if n != s:
        print(("wrote " if W else "would change ") + str(p))
        if W:
            if B:
                p.with_suffix(p.suffix + ".bak").write_text(s, encoding="utf-8")
            p.write_text(n, encoding="utf-8")
```

Оба скрипта идемпотентны: повторный запуск на уже мигрированном коде ничего не меняет.

## **Проверьте миграцию**

Текстовый поиск покажет, осталось ли что‑нибудь:

```bash
grep -rn 'aspose\.pydrawing' --include='*.py' --exclude-dir=.venv .
```

Это быстро, но также находит вхождения внутри строк и комментариев, поэтому чистый код может всё равно дать результаты. Для окончательного ответа используйте проверку ниже. Она сообщает только о реальных ссылках в коде и завершается с ненулевым статусом, если что‑то осталось, что делает её пригодной для шлагбаума сборки.

```python
import ast, sys
from pathlib import Path

MOD = "aspose.pydrawing"
ROOT = next((a for a in sys.argv[1:] if not a.startswith("-")), ".")


def chain(n):
    p = []
    while isinstance(n, ast.Attribute):
        p.append(n.attr)
        n = n.value
    return ".".join(reversed(p + [n.id])) if isinstance(n, ast.Name) else None


def scan(tree):
    for n in ast.walk(tree):
        if isinstance(n, ast.Import) and any(a.name == MOD for a in n.names):
            yield n.lineno, f"import {MOD}"
        elif isinstance(n, ast.ImportFrom) and n.module == MOD:
            names = ", ".join(a.name for a in n.names)
            yield n.lineno, f"from {MOD} import {names}"
        elif isinstance(n, ast.Attribute) and chain(n) == MOD:
            yield n.lineno, f"reference to {MOD}"


hits = 0
for p in sorted(Path(ROOT).rglob("*.py")):
    if {".venv", "venv", "__pycache__", ".git"} & set(p.parts):
        continue
    try:
        tree = ast.parse(p.read_text(encoding="utf-8"))
    except SyntaxError as e:
        print(f"skipped {p}: {e}")
        continue
    for lineno, what in sorted(scan(tree)):
        print(f"{p}:{lineno}: {what}")
        hits += 1

print("migration complete" if not hits else f"{hits} reference(s) left")
sys.exit(1 if hits else 0)
```

Запустите её до и после миграции:

```console
$ python verify.py src/
src/render.py:4: from aspose.pydrawing import Color, Point
src/render.py:11: import aspose.pydrawing
src/render.py:12: reference to aspose.pydrawing
3 reference(s) left

$ python migrate.py src/ --write
wrote src/render.py

$ python verify.py src/
migration complete
```

Наконец, запустите smoke‑тест, который проверяет перемещённые типы:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)

    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = slides.Color.red

    presentation.save("smoke.pptx", slides.export.SaveFormat.PPTX)
    print("OK")
```

## **Рекомендованный порядок миграции**

1. **Сохраните базовый вариант.** Запустите тесты на текущей версии и сохраните эталонные рендеры. Это позволит позже отделить ошибки миграции от различий в рендеринге.
2. **Предпросмотр миграции.** Запустите один из скриптов без `--write` и просмотрите список файлов, которые он изменит.
3. **Примените и проверьте.** Запустите с `--write --backup`, затем скрипт проверки и smoke‑тест.
4. **Сравните рендеры с допуском.** Переход на сборку .NET 6 может вызвать небольшие различия в тексте и эффектах. Используйте сравнение на основе порога, а не побайтовую проверку.
5. **Удалите резервные копии.** После подтверждения результата удалите файлы `.bak`: `find . -name '*.py.bak' -delete` в Linux и macOS, или `Get-ChildItem -Recurse -Filter *.py.bak | Remove-Item` в Windows.

## **Поддержка обеих версий в одной кодовой базе**

Если необходимо запускать версии 26.7 и 26.8 из одного исходного кода:

```python
try:
    from aspose.slides import Color, Point, Rectangle      # 26.8 и позже
except ImportError:
    from aspose.pydrawing import Color, Point, Rectangle   # 26.7 и ранее
```

## **Что не изменилось**

- Имена, аргументы и поведение перемещённых примитивов.
- Остальная часть API `aspose.slides`.
- Лицензирование и способ применения файла лицензии.
- Форматы файлов и поведение при сохранении и загрузке.
- Системные требования для Windows и macOS.
- Отсутствие отдельной установки .NET — среда выполнения по‑прежнему поставляется в комплекте.