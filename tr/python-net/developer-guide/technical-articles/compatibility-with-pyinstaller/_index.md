---
title: PyInstaller ve cx_Freeze ile Uyumluluk
linktitle: PyInstaller ile Uyumluluk
type: docs
weight: 122
url: /tr/python-net/compatibility-with-pyinstaller/
keywords:
- uyumluluk
- PyInstaller
- cx_Freeze
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET paketini PyInstaller ile paketleyin. Uygulamanızı bağımsız bir çalıştırılabilir dosya haline getirmek, yapılandırmak ve sorun gidermek için bu kılavuzu izleyin."
---
## **Giriş**

Aspose.Slides for Python via .NET uzantıları standart Python C uzantılarıdır, bu nedenle PyInstaller ve cx_Freeze (veya benzeri) gibi araçlarla program bağımlılıkları olarak dondurulabilir. Bu, Python betiklerinizden çalıştırılabilir dosyalar oluşturmanıza olanak tanır. Bu tür araçlara, kodunuzu ve bağımlılıklarını tek bir dağıtılabilir dosyada birleştirerek başka makinelerde Python kurulumu veya ek kütüphanelere ihtiyaç duymadan çalıştırabildikleri için “freezers” denir. Bu yaklaşım, Python uygulamalarınızı dağıtmayı basitleştirir.

Aspose.Slides for Python via .NET uzantısını bir bağımlılık olarak dondurmak, Aspose.Slides kullanan basit bir programla aşağıda gösterilmiştir.

## **PyInstaller**

Genel olarak, Aspose.Slides for Python via .NET uzantısına bağlı bir program paketlenirken özel bir şey yapılması gerekmez. Program, uzantıyı PyInstaller tarafından görülebilir şekilde içe aktardığında, uzantı programla birlikte paketlenir. Aspose.Slides for Python via .NET, PyInstaller kancaları (hooks) içerdiği için bağımlılıkları otomatik olarak algılanır ve pakete kopyalanır.

slide_app.py:
```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    slide.shapes.add_auto_shape(slides.ShapeType.LINE, 50.0, 150.0, 300.0, 0.0)
    presentation.save("NewPresentation.pptx", slides.export.SaveFormat.PPTX)
```

```bash
$ pyinstaller slide_app.py
```

Bununla birlikte, PyInstaller zaman zaman gizli içe aktarmaları (kodunuz tarafından dinamik veya dolaylı olarak içe aktarılan modüller) atlayabilir. Gizli bir içe aktarımı dahil etmek için PyInstaller seçeneklerini kullanın. Uzantının bağımlılıkları, Aspose.Slides for Python via .NET ile birlikte gelen PyInstaller kancalarında belirtilmiştir.

slide_app.spec:
```
a = Analysis(
    ['slide_app.py'],
    ...
    hiddenimports=['aspose.slides']
)
```

```bash
$ pyinstaller slide_app.spec
```

## **cx_Freeze**

cx_Freeze ile bir programı dondurmak için, kullandığınız Aspose.Slides for Python via .NET uzantısının kök paketini dahil edecek şekilde yapılandırın. Bu, uzantının ve tüm bağımlı modüllerin uygulamanızla birlikte derlemeye kopyalanmasını sağlar.

### **cxfreeze betiğini kullanma**

```bash
$ cxfreeze slide_app.py --packages=aspose
```

### **Setup betiğini kullanma**

setup.py:
```
executables = [Executable('slide_app.py')]

options = {
    'build_exe': {
        'packages': ['aspose'],
    }
}

setup(...
    options=options,
    executables=executables)
```

```bash
$ python setup.py build_exe
```

## **SSS**

**Kullanıcının makinesinde Microsoft PowerPoint veya .NET yüklü olması gerekiyor mu?**

Hayır, PowerPoint gerekli değildir. Aspose.Slides, kendi içinde çalışan bir motor; Python paketi, CPython için bir uzantı olarak gereken her şeyi içerir. Kullanıcının .NET'i ayrı olarak kurmasına gerek yoktur.

**Bir dondurulmuş uygulamaya lisansı doğru şekilde nasıl eklemeliyim?**

Lisans XML dosyasını çalıştırılabilir dosyanın yanına koyabilir veya bir kaynak olarak gömebilir ve ilk API çağrısından önce erişilebilir bir yoldan yükleyebilirsiniz. Önemli: XML içeriğini (satır sonları dahil) değiştirmeyin.

**Derleme sonrasında fontların, geliştirme ortamına göre farklı görüntülenmesi durumunda ne yapmalıyım?**

Kullandığınız fontların hedef ortamda (paketlenmiş veya sistemde yüklü) mevcut olduğundan ve çalışma zamanında yollarının doğru çözüldüğünden emin olun; özellikle Linux'ta font davranışı çok hassastır.