---
title: Sürüm 26.8'de Yeni Python-.NET Motoruna Geçiş
linktitle: Yeni Motora Geçiş
type: docs
weight: 290
url: /tr/python-net/migrate-to-new-engine/
keywords:
- yeni motor
- geçiş
- aspose.pydrawing
- çizim primitifleri
- Point
- Color
- Rectangle
- ImportError
- AttributeError
- Python
- Aspose.Slides
description: "Python kodunuzu sürüm 26.8'deki yeni Aspose.Slides motoruna taşıyın: çizim primitiflerini aspose.slides'a yeniden konumlandırın ve import işlemlerini otomatik olarak düzeltin."
---
## **Giriş**

Version 26.8, Python'u .NET'e bağlayan motoru değiştirir. Çizim primitifleri `aspose.slides` modülüne taşındı.

Güncelleme sonrası bir sorun yaşıyorsanız doğrudan [I Have an Error](#i-have-an-error) bölümüne gidin.

### **Çizim Primitifleri aspose.slides'a Taşındı**

Yedi tip taşındı. İsimlerini, argümanlarını ve davranışlarını korurlar:

|Tip|26.8 Öncesi|26.8 ve Sonrası|
| :- | :- | :- |
|Point|`aspose.pydrawing.Point`|[aspose.slides.Point](https://reference.aspose.com/slides/tr/python-net/aspose.slides/point/)|
|PointF|`aspose.pydrawing.PointF`|[aspose.slides.PointF](https://reference.aspose.com/slides/tr/python-net/aspose.slides/pointf/)|
|Size|`aspose.pydrawing.Size`|[aspose.slides.Size](https://reference.aspose.com/slides/tr/python-net/aspose.slides/size/)|
|SizeF|`aspose.pydrawing.SizeF`|[aspose.slides.SizeF](https://reference.aspose.com/slides/tr/python-net/aspose.slides/sizef/)|
|Rectangle|`aspose.pydrawing.Rectangle`|[aspose.slides.Rectangle](https://reference.aspose.com/slides/tr/python-net/aspose.slides/rectangle/)|
|RectangleF|`aspose.pydrawing.RectangleF`|[aspose.slides.RectangleF](https://reference.aspose.com/slides/tr/python-net/aspose.slides/rectanglef/)|
|Color|`aspose.pydrawing.Color`|[aspose.slides.Color](https://reference.aspose.com/slides/tr/python-net/aspose.slides/color/)|

Bu yedi tip, `aspose.pydrawing`'in geriye kalan tüm içeriğiydi. Onları yeniden yönlendirdiğinizde, kodunuzun hiçbir yerinde `aspose.pydrawing` referansına gerek kalmaz ve tüm import'ları kaldırılabilir. Bu aynı zamanda sonucu kontrol etmeyi de kolaylaştırır - bakınız [Verify the Migration](#verify-the-migration).

**Eski kod:**

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

**Sürüm 26.8:**

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

`from` import biçimi aynı şekilde değişir:

```python
# Eski kod
from aspose.pydrawing import Color, Point

# Sürüm 26.8
from aspose.slides import Color, Point
```

## **Import Hatasını Düzeltin**

İzleme çıktınızı (traceback) ilk sütunda bulun.

|Hata|Neden|Düzeltme|
| :- | :- | :- |
|`AttributeError: module 'aspose.pydrawing' has no attribute 'Color'` (veya `Point`, `Rectangle` vb.)|Paket 26.8, kod hâlâ eski modüle işaret ediyor|[Update your code](#update-your-code)|
|`ImportError: cannot import name 'Color' from 'aspose.pydrawing'`|Aynı neden, `from` import biçimi|[Update your code](#update-your-code)|
|`ModuleNotFoundError: No module named 'aspose.pydrawing'`|Modül ve onun yedi tipi `aspose.slides` içine taşındı|[Update your code](#update-your-code), then delete the `aspose.pydrawing` import|
|`ImportError: cannot import name 'Color' from 'aspose.slides'`|Kod taşındı, ancak kurulu paket 26.7 veya daha eski|`pip install --upgrade aspose.slides`|
|`TypeError` on a color, point, or size argument|`aspose.pydrawing`'den oluşturulan bir değer yeni API'ye geçiriliyor|Create the value from `aspose.slides` as well|

## **Kodunuzu Güncelleyin**

`aspose.pydrawing`'in yalnızca taşınan yedi tip dışında içeriği olmadığı için, geçiş modülün yeniden adlandırılmasıdır. Tüm import biçimleri bu tek yeniden adlandırma ile kapsanır, alias'lar dahil:

```python
# Eski kod
import aspose.pydrawing as drawing
color = drawing.Color.red

# Sürüm 26.8 - alias çalışmaya devam ediyor
import aspose.slides as drawing
color = drawing.Color.red
```

Bu, bir fonksiyon gövdesi içinde de dahil olmak üzere her kapsamda geçerlidir, çünkü alias tam olarak önce bağlandığı yerde kalır. Tek dezavantajı yanıltıcı bir isim olmasıdır, bu yüzden amacı açıkça belirtmeyi düşünün:

```python
import aspose.slides as slides
color = slides.Color.red
```

Kod tabanınızın büyüklüğüne uygun yaklaşımı seçin.

### **Manuel Değiştirme**

Birkaç dosya için, `aspose.pydrawing`'i arayın ve `aspose.slides` ile değiştirin, ardından gereksiz kalan import'ları kaldırın.

### **Kabuk Komutuyla Değiştirme**

Bu düz metin değiştirmesidir, bu yüzden dizeler ve yorum içindeki kullanımları da etkiler. Her iki komut da değiştirilen her dosyanın bir `.bak` kopyasını yazar.

**Linux:**

```bash
grep -rlZ --include='*.py' 'aspose\.pydrawing' . \
  | xargs -0 -r sed -i.bak 's/aspose\.pydrawing/aspose.slides/g'
```

macOS'ta `sed -i ''` kullanın, `sed -i.bak` yerine, ya da GNU sed'i `gsed` olarak kurun.

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

Linux ya da macOS'ta geri almak için:

```bash
find . -name '*.py.bak' -exec sh -c 'mv "$1" "${1%.bak}"' _ {} \;
```

Windows'da geri almak için:

```
Get-ChildItem -Recurse -Filter *.py.bak | ForEach-Object {
  Move-Item $_.FullName ($_.FullName -replace '\.bak$', '') -Force
}
```

### **Python Betiğiyle Değiştirme**

Aynı yeniden adlandırma, Linux, macOS ve Windows'ta taşınabilir. Betik yolu bir argüman olarak alır ve `--write` verilmedikçe değişiklikleri önizler. `--backup` ekleyerek her değiştirilen dosyanın bir `.bak` kopyasını tutar. İstediğiniz bir adla kaydedin - kullanım mesajı çalışma zamanında adı alır.

```python
"""aspose.pydrawing'i aspose.slides'a yeniden adlandırın. Düz metin değiştirme.

    python <this script> src/                     # ön izleme
    python <this script> src/ --write             # uygula
    python <this script> src/ --write --backup    # uygula, .bak kopyalarını tutarak
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

Tipik bir çalıştırma şu şekildedir:

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

Yol bir dizin olabilir, özyinelemeli olarak dolaşılır, ya da tek bir `.py` dosyası.

### **AST Tabanlı Betikle Değiştirme**

Daha büyük kod tabanları için önerilir. Bu betik aynı yeniden adlandırmayı yapar, ancak her dosyayı önce ayrıştırır, böylece dizeler, yorumlar veya dokstring'lerdeki kullanımlara dokunmaz.

Modülü yerinde yeniden adlandırdığı ve alias'ları bıraktığı için, tüm import biçimleri özel durumlar olmadan işlenir: `import aspose.pydrawing`, `import aspose.pydrawing as X`, `from aspose.pydrawing import Color`, `from aspose.pydrawing import Color as C`, çok satırlı parantezli import'lar, fonksiyon içindeki import'lar ve değer olarak geçirilen modül. Aynı `--write` ve `--backup` bayraklarını kabul eder.

```python
"""aspose.pydrawing'i aspose.slides'a yeniden adlandırın, dizeleri ve yorumları atlayarak.

    python <this script> src/                     # ön izleme
    python <this script> src/ --write             # uygula
    python <this script> src/ --write --backup    # uygula, .bak kopyalarını tutarak
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
        # import aspose.pydrawing [as X]  /  from aspose.pydrawing import ...
        # Modül adı yerinde yeniden adlandırılır, böylece mevcut takma adlar aynı şekilde kalır.
        if (isinstance(n, ast.Import) and any(a.name == MOD for a in n.names)) or \
           (isinstance(n, ast.ImportFrom) and n.module == MOD):
            s, e = off[n.lineno - 1], off[n.end_lineno - 1] + n.end_col_offset
            edits.append((s, e, src.encode()[s:e].decode().replace(MOD, DST)))
        # Modüle referans yapan herhangi bir ifade, çıplak `fn(aspose.pydrawing)` dahil.
        elif isinstance(n, ast.Attribute) and chain(n) == MOD:
            edits.append((off[n.lineno - 1] + n.col_offset,
                          off[n.end_lineno - 1] + n.end_col_offset, DST))

    b = src.encode()
    for s, e, r in sorted(edits, reverse=True):  # sondan başa doğru işlemek offset'leri geçerli tutar
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

Her iki betik de idempotent'tir: taşınmış kodda tekrar çalıştırıldıklarında hiçbir şey değişmez.

## **Geçişi Doğrulama**

Metin araması, herhangi bir kalıntı olup olmadığını gösterir:

```bash
grep -rn 'aspose\.pydrawing' --include='*.py' --exclude-dir=.venv .
```

Bu hızlıdır, ancak dizeler ve yorumlar içinde de eşleşir, bu yüzden temiz kod bile eşleşme üretebilir. Kesin bir cevap için aşağıdaki kontrolü kullanın. Yalnızca gerçek kod referanslarını raporlar ve kalıntı varsa sıfır olmayan bir durum kodu ile çıkar, bu da onu bir derleme aşaması olarak kullanılabilir kılar.

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

Geçişten önce ve sonra çalıştırın:

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

Son olarak, taşınan tipleri kullanan bir smoke test çalıştırın:

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

## **Önerilen Geçiş Sırası**

1. **Bir temel kaydedin.** Mevcut sürümde testlerinizi çalıştırın ve referans render'ları saklayın. Bu, geçiş hatalarını sonraki render farklılıklarından ayırmanıza olanak tanır.
2. **Geçişi önizleyin.** Betiklerden birini `--write` olmadan çalıştırın ve değiştireceği dosya listesini inceleyin.
3. **Uygulayın ve doğrulayın.** `--write --backup` ile çalıştırın, ardından doğrulama betiğini ve smoke test'i yürütün.
4. **Render'ları toleransla karşılaştırın.** .NET 6 derlemesine geçiş, metin ve efektlerde küçük farklılıklar oluşturabilir. Byte bazlı kontrol yerine eşik tabanlı bir karşılaştırma kullanın.
5. **Yedekleri silin.** Sonuç onaylandığında `.bak` dosyalarını silin: Linux ve macOS'ta `find . -name '*.py.bak' -delete`, Windows'ta `Get-ChildItem -Recurse -Filter *.py.bak | Remove-Item`.

## **Tek Kod Tabanında Her İki Sürümü de Destekleme**

Aynı kaynak kodundan 26.7 ve 26.8 ile çalışmanız gerekiyorsa:

```python
try:
    from aspose.slides import Color, Point, Rectangle      # 26.8 ve sonrası
except ImportError:
    from aspose.pydrawing import Color, Point, Rectangle   # 26.7 ve öncesi
```

## **Değişmeyenler**

- Taşınan primitiflerin adları, argümanları ve davranışları.
- `aspose.slides` API'sinin geri kalan kısmı.
- Lisanslama ve lisans dosyasının uygulanma şekli.
- Dosya formatları ve kaydetme/yükleme davranışı.
- Windows ve macOS üzerindeki sistem gereksinimleri.
- Ayrı bir .NET kurulumunun olmaması - çalışma zamanı hâlâ paketlenmiş.